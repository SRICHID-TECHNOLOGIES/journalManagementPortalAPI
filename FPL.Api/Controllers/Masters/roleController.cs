
//using DocumentFormat.OpenXml.Wordprocessing;
//using FPL.Dal.DataModel;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace FactorsPrivateLimited.Controllers.Masters
//{
//    public class roleController : ApiController
//    {
//        private factosprivatelimitedEntities db = new factosprivatelimitedEntities();
//        //public UserRole usrrole = new UserRole();
//       // private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(roleController));
      
//       // public UserRole usrrole = new UserRole();
//       [HttpGet]
//        public async Task<IHttpActionResult> GetAllRoles()
//        {
//            var result = await Task.Run(() => db.RoleMasters.ToList());
//            return Ok(result);
//        }

//        public async Task<IHttpActionResult> PostSaveRole(RoleMasterDetails data1)
//        {
//            var timer = Stopwatch.StartNew();

//          //  _logger.Info("Role Saving is starting...");
//           // _logger.Warn("Looks like nothing is really happening in this...");
//            try
//            {
//                RoleMaster data = new RoleMaster()
//                {
//                    Id = 0,
//                    RoleName = data1.RoleName,
//                    CreatedOn = DateTime.Now,
//                    CreatedBy = "Admin"
//                };

//                await Task.Run(() => db.RoleMasters.Add(data));
//                await db.SaveChangesAsync();

//                return Ok("success");
//            }
//            catch (Exception e)
//            {
//             //   _logger.Error("Hmm... something went as unexpected", e);
//                throw e;
//            }
//            finally
//            {
//               // _logger.InfoFormat("Role Saved Successfully in {0}ms", timer.ElapsedMilliseconds);
//            }
//        }
//        [HttpPost]
//        public async Task<IHttpActionResult> PutRole(RoleMasterDetails data1)
//        {
//            var timer = Stopwatch.StartNew();

//           // _logger.Info("Role Edit is starting...");
//          //  _logger.Warn("Looks like nothing is really happening in this...");
//            try
//            {
//                var data = db.RoleMasters.Where(c => c.Id == data1.Id).FirstOrDefault();
//                data.ModifiedBy = "Admin";
//                data.ModifiedOn = DateTime.Now;
//                data.RoleName = data1.RoleName;
//                data.CreatedBy = data1.CreatedBy;
//                data.CreatedOn = data1.CreatedOn;

//                await Task.Run(() => db.Entry(data).State = EntityState.Modified);
//                await db.SaveChangesAsync();

//                return Ok("success");
//            }
//            catch (Exception e)
//            {
//           //     _logger.Error("Hmm... something went as unexpected", e);
//                throw e;
//            }
//            finally
//            {
//              //  _logger.InfoFormat("Role Modified Successfully in {0}ms", timer.ElapsedMilliseconds);
//            }
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> DeleteRoleData([FromUri(Name = "id")] int id)
//        {
//            var data = await Task.Run(() => db.RoleMasters.FindAsync(id));

//            await Task.Run(() => db.RoleMasters.Remove(data));
//            await db.SaveChangesAsync();

//            return Ok("success");
//        }
//        public partial class RoleMasterDetails
//        {
//            public int Id { get; set; }
//            public string RoleName { get; set; }
//            public string UserId { get; set; }
//            public Nullable<System.DateTime> CreatedOn { get; set; }
//            public string CreatedBy { get; set; }
//            public Nullable<System.DateTime> ModifiedOn { get; set; }
//            public string ModifiedBy { get; set; }
//        }
//    }
//}
