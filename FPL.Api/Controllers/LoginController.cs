using Application.Security;
using db;
using FPL.Dal.DataModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Register_Table = FPL.Dal.DataModel.Register_Table;

namespace FPL.Api.Controllers
{
    public class LoginController : ApiController
    {
        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();

        public class User
        {
            public int UserId { get; set; }
            public string userName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int? RoleID { get; set; }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Signin(LoginUserModel model)
        {
            try
            {
                var email = model.Email;

                var user = db.Register_Table.Where(x => x.Email == email).FirstOrDefault();
                if (user == null || user.Password != model.Password)
                {
                    return Ok("fail");
                }
                var token = GenerateJwtToken(user);
                var data = new Register_TableVM()
                {
                    Email = user.Email,
                    RoleID = user.RoleID,
                    Token = token,
                    RegisterID = user.RegisterID,
                    FullName = user.FullName,
                };
                return Ok(data);
            }
            catch (Exception e)
            {

                throw;
            }
          
        }

        [HttpPost]
        public async Task<IHttpActionResult> savelogin(Register_Table data)
        {
            try
            {
                Register_Table login = new Register_Table()
                {
                    Email = data.Email,
                    Password = data.Password,

                };
                db.Register_Table.Add(login);
                db.SaveChanges();
                return Ok("success");
            }
            catch (Exception e)
            {

                return Ok("fail");
            }
        }
        public class Register_TableVM
        {
            public int RegisterID { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }

            public int? RoleID { get; set; }

        }

        private string GenerateJwtToken(Register_Table user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var keys = user.Email + user.Email + user.FullName;
                var key = Encoding.ASCII.GetBytes(keys);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new[]
                    {
                    new Claim("email", user.Email),
                    new Claim("fullname", user.FullName),
                    new Claim("roleid", user.RoleID.ToString()),
                    new Claim("registerid", user.RegisterID.ToString()),
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
