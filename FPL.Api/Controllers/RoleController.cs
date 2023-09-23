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
    public class RoleController : ApiController
    {

        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();
        [HttpPost]
        public async Task<IHttpActionResult> Saverole(Role_table data)
        {
            try
            {
                Role_table role = new Role_table()
                {
                    RoleName = data.RoleName,
                    CreatedOn = DateTime.Now,
                   
                };
                db.Role_table.Add(role);
                db.SaveChanges();
                return Ok("success");
            }
            catch (Exception e)
            {

                return Ok("fail");
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetroleData()
        {
            try
            {
                var roleData = db.Role_table.ToList();
                return Ok(roleData);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Editrole(roleDataModel data1)
        {
            try
            {
                var data = db.Role_table.Where(c => c.RoleID == data1.RoleID).FirstOrDefault();
                data.RoleName = data1.RoleName;
                await Task.Run(() => db.Entry(data).State = EntityState.Modified);
                await db.SaveChangesAsync();
                return Ok("success");
            }

            catch (Exception e)
            {
                throw e;
            }
        }

      

        [HttpGet]
        public async Task<IHttpActionResult> deleteroleData([FromUri(Name = "id")] int id)
        {
            try
            {
                var roledata = db.Role_table.Where(c => c.RoleID == id).FirstOrDefault();

                await Task.Run(() => db.Role_table.Remove(roledata));
                await Task.Run(() => db.SaveChangesAsync());
                return Ok("success");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public partial class roleDataModel
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
        }
    }
}
