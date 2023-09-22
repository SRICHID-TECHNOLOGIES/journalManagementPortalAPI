//using FPL.Dal.DataModel;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;

//namespace FPL.Api.Controllers
//{
//    public class FileuploadController : ApiController
//    {
//        private fileuploadEntities db = new fileuploadEntities();
//        [HttpPost]
//        public async Task<IHttpActionResult> fileupload()
//        {
//            try
//            {
//                var httpRequest = HttpContext.Current.Request;

//                // Loop through uploaded files
//                foreach (string fileKey in httpRequest.Files)
//                {
//                    var hpf = httpRequest.Files[fileKey];
//                    var doclink = GetDocumentorfileUri(hpf);

//                    // Read file data into a byte array
//                    byte[] fileData;
//                    using (var binaryReader = new BinaryReader(hpf.InputStream))
//                    {
//                        fileData = binaryReader.ReadBytes(hpf.ContentLength);
//                    }

//                    // Create a new fileUpload entity
//                    var doc = new fileUpload()
//                    {
//                        bloburl = doclink,
//                        filename = hpf.FileName,
//                        filetype = hpf.ContentType,
//                        createdon = DateTime.Now
//                    };

//                    // Add the entity to the context and save changes
//                    db.fileUploads.Add(doc);
//                }

//                // Outside the loop, save changes once
//                await db.SaveChangesAsync();

//                return Ok("success");
//            }
//            catch (Exception e)
//            {
//                // Handle exceptions appropriately
//                return InternalServerError(e);
//            }
//        }


//        public static string GetDocumentorfileUri(HttpPostedFile fileorimage)
//        {
//            if (fileorimage.ContentLength > 0)
//            {
//                BlobStorage.UploadFile(fileorimage);
//                string doiuri = BlobStorage.DocumentsorImagesUri.ToString();
//                return doiuri;
//            }
//            return "Nill";
//        }

//        public static class BlobStorage
//        {
//            internal static void UploadFile(HttpPostedFile photoToUpload)
//            {
//                try
//                {

//                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=accountdatastorage;AccountKey=/0cntcHDwClHBA5N6fkdMr/31ejNnjhkrf0Wzjyw2ZedAcUnDg8YHFqq1we4yaCHRUSp3+0Mbw5EtFrMNsU3Fw==;EndpointSuffix=core.windows.net");
//                    //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

//                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
//                    // Retrieve a reference to a container. 
//                    CloudBlobContainer container = blobClient.GetContainerReference("pictures");

//                    // Create the container if it doesn't already exist.
//                    container.CreateIfNotExists();

//                    container.SetPermissions(
//                     new BlobContainerPermissions
//                     {
//                         PublicAccess = BlobContainerPublicAccessType.Blob
//                     });
//                    // Retrieve reference to a blob named "filename...".
//                    string imageName = String.Format("task-photo-{0}{1}",
//                     Guid.NewGuid().ToString(),
//                     Path.GetExtension(photoToUpload.FileName));
//                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
//                    DocumentsorImagesUri = blockBlob.Uri;
//                    blockBlob.UploadFromStream(photoToUpload.InputStream);

//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//            }
//            public static Uri DocumentsorImagesUri { get; set; }

//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> Getalldata()
//        {
//            var res = db.fileUploads.ToList();
//            return Ok(res);
//        }

//    }
//}
