using DocumentFormat.OpenXml.Office2010.Excel;
using FPL.Dal.DataModel;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace FPL.Api.Controllers
{
    public class ManuscriptController : ApiController
    {
        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();

        [HttpGet]
        public async Task<IHttpActionResult> FetchManuscriptNumber()
        {
            try
            {
                var ManuscriptID = db.ManuscriptSubs.ToList();
                return Ok(ManuscriptID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        [HttpGet]
        public async Task<IHttpActionResult> getmanuscriptsubmissionData()
        {
            try
            {
                var getmanuscriptcontentData = db.ManuscriptSubs.ToList();
                return Ok(getmanuscriptcontentData);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpPost]
        public async Task<IHttpActionResult> Fileupload()
        {
            try
            {
                HttpPostedFile hpf;
                //HttpPostedFile udl;
                //HttpPostedFile mpl;
                var httpRequest = HttpContext.Current.Request;
                var Plagiarismdoclink = httpRequest["FileBlobLink"];
                var undertakingdoclink =httpRequest["UndertakingFileBlobLink"];
                var manuscriptPDFLink = httpRequest["ManuscriptPDFLink"];
                var manuscriptNo = httpRequest["ManuscriptNo"];
                var subjects = httpRequest["Subject"];
                var subjectId = Convert.ToInt32(subjects);
                var subjectName = db.subjectcontent_Table.Where(c => c.SubjectID == subjectId).Select(c => c.SubjectName).FirstOrDefault();
                var title = httpRequest["Title"];
                var manuscripttype = httpRequest["ManuscriptType"];
                var ManuscriptID = Convert.ToInt32(manuscripttype);
                var ManuscriptName = db.Manuscript_Table.Where(c => c.ManuscriptID == ManuscriptID).Select(c => c.ManuscriptName).FirstOrDefault();
                var abstracts = httpRequest["Abstract"];
                var doclink = "";
                var Plagiarismdocname = "";
                var UndertakingDocName = "";
                var ManuscriptPDFName = "";

                var email = httpRequest["Email"];
                var RegisterID = httpRequest["RegisterID"];
                var RID = Convert.ToInt32(RegisterID);
                var authorName = db.Register_Table.Where(c => c.RegisterID == RID).Select(c => c.FullName).FirstOrDefault();

                byte[] fileData = null;
                HttpFileCollection hfc = HttpContext.Current.Request.Files;

                // Loop through uploaded files

                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    hpf = hfc[iCnt];
                    doclink = GetDocumentorfileUri(hpf);

                    if(doclink != null)
                    {
                        if(hfc.AllKeys[iCnt] == "FileBlobLink")
                        {
                            Plagiarismdoclink = doclink;
                            Plagiarismdocname = hpf.FileName;
                        }

                        if(hfc.AllKeys[iCnt] == "UndertakingFileBlobLink")
                        {
                            undertakingdoclink = doclink;
                            UndertakingDocName = hpf.FileName;
                        }

                        if (hfc.AllKeys[iCnt] == "ManuscriptPDFLink")
                        {
                            manuscriptPDFLink = doclink;
                            ManuscriptPDFName = hpf.FileName;
                        }
                    }
                    using (var binaryReader = new BinaryReader(hpf.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(hpf.ContentLength);
                    }
                }

                    // foreach (string fileKey in httpRequest.Files)
                    // {
                    //var hpf = httpRequest.Files[fileKey];
                    //var mpl = httpRequest.Files[fileKey];
                    //var udl = httpRequest.Files[fileKey];
                    //Plagiarismdoclink = GetDocumentorfileUri(hpf);
                    //undertakingdoclink = GetDocumentorfileUri(udl);
                    //manuscriptPDFLink = GetDocumentorfileUri(mpl);

                    // Read file data into a byte array
                    //byte[] fileData;
                    //using (var binaryReader = new BinaryReader(hpf.InputStream))
                    //{
                    //    fileData = binaryReader.ReadBytes(hpf.ContentLength);
                    //}

                    // Create a new fileUpload entity
                    //  }
                    ManuscriptSub doc = new ManuscriptSub()
                {
                    Plagiarismurl = Plagiarismdoclink,
                    Undertakingdocurl = undertakingdoclink,
                    ManuscriptPDF = manuscriptPDFLink,
                    ManuscriptNo = manuscriptNo,
                    Subject = subjectName,
                    Title = title,
                    ManuscriptTypeID = ManuscriptID,
                    ManuscriptType = ManuscriptName,
                    Abstract = abstracts,
                    CreatedOn = DateTime.Now,
                    Plagiarismdocname = Plagiarismdocname,
                    UndertakingDocName = UndertakingDocName,
                    ManuscriptPDFName = ManuscriptPDFName,
                    TitleID = subjectId,
                    RegisterID = RID,
                    AuthorName = authorName,
                    };








                // Add the entity to the context and save changes
            
                db.ManuscriptSubs.Add(doc);

            // Outside the loop, save changes once
            await db.SaveChangesAsync();

                return Ok("success");
            }
            catch (Exception e)
            {
                // Handle exceptions appropriately
                throw e ;
            }
        }

       

        [HttpGet]
        public async Task<IHttpActionResult> GetManuscriptDetailsByRegisterID([FromUri(Name = "id")] int id)
        {
            try
            {
               
                var manuscriptcontentData = db.ManuscriptSubs.Where(c => c.RegisterID == id).ToList();
                return Ok(manuscriptcontentData);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static string GetDocumentorfileUri(HttpPostedFile fileorimage)
        {
            if (fileorimage.ContentLength > 0)
            {
                BlobStorage.UploadFile(fileorimage);
                string doiuri = BlobStorage.DocumentsorImagesUri.ToString();
                return doiuri;
            }
            return "Nill";
        }

        public static class BlobStorage
        {
            internal static void UploadFile(HttpPostedFile photoToUpload)
            {
                try
                {

                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=accountdatastorage;AccountKey=/0cntcHDwClHBA5N6fkdMr/31ejNnjhkrf0Wzjyw2ZedAcUnDg8YHFqq1we4yaCHRUSp3+0Mbw5EtFrMNsU3Fw==;EndpointSuffix=core.windows.net");
                    //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    // Retrieve a reference to a container. 
                    CloudBlobContainer container = blobClient.GetContainerReference("pictures");

                    // Create the container if it doesn't already exist.
                    container.CreateIfNotExists();

                    container.SetPermissions(
                     new BlobContainerPermissions
                     {
                         PublicAccess = BlobContainerPublicAccessType.Blob
                     });
                    // Retrieve reference to a blob named "filename...".
                    string imageName = String.Format("task-photo-{0}{1}",
                     Guid.NewGuid().ToString(),
                     Path.GetExtension(photoToUpload.FileName));
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
                    DocumentsorImagesUri = blockBlob.Uri;
                    blockBlob.UploadFromStream(photoToUpload.InputStream);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public static Uri DocumentsorImagesUri { get; set; }

        }


    }
}
