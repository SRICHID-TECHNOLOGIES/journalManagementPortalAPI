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
    public class ManuscriptContentController : ApiController
    {
        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();

        [HttpPost]
        public async Task<IHttpActionResult> savemanuscriptcontent(manuscriptDataModel data)
        {
            try
            {
                Manuscript_Table manuscript = new Manuscript_Table()
                {
                    ManuscriptName = data.ManuscriptName,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };

                db.Manuscript_Table.Add(manuscript);
                db.SaveChanges();

                return Ok("success");
            }

            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> getmanuscriptcontentData()
        {
            try
            {
                var getmanuscriptcontentData = db.Manuscript_Table.ToList();
                return Ok(getmanuscriptcontentData);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Editmanuscriptcontent(manuscriptDataModel data1)
        {
            try
            {
                var data = db.Manuscript_Table.Where(c => c.ManuscriptID == data1.ManuscriptID).FirstOrDefault();
                data.ManuscriptName = data1.ManuscriptName;
                await Task.Run(() => db.Entry(data).State = EntityState.Modified);
                await db.SaveChangesAsync();
                return Ok("success");
            }

            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> savemanuscript(manuscriptDataModel data)
        {
            try
            {
                Manuscript_Table manuscript = new Manuscript_Table()
                {
                    ManuscriptName = data.ManuscriptName,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                db.Manuscript_Table.Add(manuscript);
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
        public async Task<IHttpActionResult> DeletemanuscripData([FromUri(Name = "id")] int id)
        {
            try
            {
                var maanuscriptdata = db.Manuscript_Table.Where(c => c.ManuscriptID == id).FirstOrDefault();

                await Task.Run(() => db.Manuscript_Table.Remove(maanuscriptdata));
                await Task.Run(() => db.SaveChangesAsync());
                return Ok("success");
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public partial class manuscriptDataModel
        {
            public int ManuscriptID { get; set; }
            public string ManuscriptName { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }

        }

    }
}
