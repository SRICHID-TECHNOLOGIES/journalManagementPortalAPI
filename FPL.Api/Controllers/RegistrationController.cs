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
    public class RegistrationController : ApiController
    {
        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();
        private string password;

        private string confirmPassword;

        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }

        [HttpPost]
        public async Task<IHttpActionResult> registerregistration(registerDataModel data)
        {
            try
            {
                Register_Table registration = new Register_Table()
                {
                    RegisterID = data.RegisterID,
                    FullName = data.FullName,
                    Phone = data.Phone,
                    Email = data.Email,
                    Profession = data.Profession,
                    Organisation = data.Organisation,
                    College = data.College,
                    PostalAddress = data.PostalAddress,
                    Area = data.Area,
                    City = data.City,
                    State = data.State,
                    Pincode = data.Pincode,
                    CreratedOn = DateTime.Now,
                    Password = data.Password,
                    ConfirmPassword = data.ConfirmPassword
                };
                db.Register_Table.Add(registration);
                db.SaveChanges();
                return Ok("success");
            }
            catch (Exception e)
            {
                return Ok("fail");
            }

        }

        [HttpGet]
        public async Task<IHttpActionResult> getEmailid()
        {
            try
            {
                var emailID = db.Register_Table.ToList();
                return Ok(emailID);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CheckEmailMatch(registerDataModel data1)
        {
            try
            {
                var data = db.Register_Table.Where(c => c.Email == data1.Email).FirstOrDefault();
                if(data!= null)
                {
                    return Ok("yes");
                }
                else
                {
                    return Ok("no");
                }
         
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SavePassword(registerDataModel data1)
        {
            try
            {
                Register_Table UpdatedPasswordData = new Register_Table();
                {
                    var data = db.Register_Table.Where(c => c.Email == data1.Email).FirstOrDefault();
                    data.Password = data1.Password;
                    data.ConfirmPassword = data1.Password;
                    Task.Run(() => db.Entry(data).State = EntityState.Modified);
                    db.SaveChangesAsync();
                }             
                return Ok("success");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> getregistrationData()
        {
            try
            {
                var registrationData = db.Register_Table.ToList();
                return Ok(registrationData);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

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


        public partial class registerDataModel
        {

            public string FullName { get; set; }
            public int RegisterID { get; set; }
            public int Phone { get; set; }
            public string Email { get; set; }
            public string Profession { get; set; }

            public string Organisation { get; set; }
            public string College { get; set; }
            public string PostalAddress { get; set; }
            public string Area { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int Pincode { get; set; }
            public string Password { get; set; }

            public string ConfirmPassword { get; set; }
            public string Captcha { get; set; }

            public Nullable<System.DateTime> CreratedOn { get; set; }

            public Nullable<System.DateTime> ModifiedOn { get; set; }
            

        }
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

        
    }
}
