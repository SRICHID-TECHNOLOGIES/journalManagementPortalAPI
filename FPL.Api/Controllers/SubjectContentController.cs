using FPL.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FPL.Api.Controllers
{
    public class SubjectContentController : ApiController
    {
        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();
       
        [HttpPost]
        public async Task<IHttpActionResult> Savesubjectcontent(subjectcontent_Table data)
        {
            try
            {
                subjectcontent_Table subjectcontent = new subjectcontent_Table()
                {
                    SubjectName = data.SubjectName,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                db.subjectcontent_Table.Add(subjectcontent);
                db.SaveChanges();
                return Ok("success");
            }
            catch (Exception e)
            {

                return Ok("fail");
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetsubjectcontentData()
        {
            try
            {
                var subjectcontentData = db.subjectcontent_Table.ToList();
                return Ok(subjectcontentData);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Editsubjectcontent(subjectcontentDataModel data1)
        {
            try
            {
                var data = db.subjectcontent_Table.Where(c => c.SubjectID == data1.SubjectID).FirstOrDefault();
                data.SubjectName = data1.SubjectName;
                await Task.Run(() => db.Entry(data).State = EntityState.Modified);
                await db.SaveChangesAsync();
                return Ok("success");
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> savesubjectcontent(subjectcontentDataModel data)
        {
            try
            {
                subjectcontent_Table subject = new subjectcontent_Table()
                {
                    SubjectName = data.SubjectName,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                db.subjectcontent_Table.Add(subject);
                db.SaveChangesAsync();
                return Ok("success");
            }
            catch (Exception e)
            {

                throw e;
                return Ok("fail");
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> deletesubjectcontentData([FromUri(Name = "id")] int id)
        {
            try
            {
                var subjectcontentdata = db.subjectcontent_Table.Where(c => c.SubjectID == id).FirstOrDefault();

                await Task.Run(() => db.subjectcontent_Table.Remove(subjectcontentdata));
                await Task.Run(() => db.SaveChangesAsync());
                return Ok("success");
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public  class subjectcontentDataModel
        {
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }
        }
    }
}
