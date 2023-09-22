//using FPL.Dal.datamodel;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace FPL.Api.Controllers
//{
//    public class CountryController : ApiController
//    {
//        private countryEntities db = new countryEntities();
//        public class countrydata
//        {
//            public string countryname { get; set; }
//        }
//        [HttpPost]
//        public async Task<IHttpActionResult> onclick(countrydata data)
//        {
//            try
//            {
//                countrytable country = new countrytable()
//                {
//                    countryname = data.countryname,

//                };
//                db.countrytables.Add(country);
//                await db.SaveChangesAsync();
//                return Ok("success");
//            }
//            catch (Exception e)
//            {
//                throw e;
//                return Ok("fail");
//            }
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> Getcountrydata()
//        {
//            try
//            {
//                var countryData = db.countrytables.ToList();
//                return Ok(countryData);
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> DeleteCountryData([FromUri(Name = "id")] int id)
//        {
//            try
//            {
//                var countryData = db.countrytables.Where(c => c.id == id).FirstOrDefault();

//                await Task.Run(() => db.countrytables.Remove(countryData));
//                await Task.Run(() => db.SaveChangesAsync());
//                return Ok("success");

//            }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }

//        [HttpPost]
//        public async Task<IHttpActionResult> EditCountry(countrytableDataModel id)
//        {
//            try
//            {
//                var data = db.countrytables.Where(c => c.id == c.id).FirstOrDefault();
//                data.countryname = id.countryname;
//                await Task.Run(() => db.Entry(data).State = EntityState.Modified);
//                await db.SaveChangesAsync();
//                return Ok("success");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        public class countrytableDataModels
//        {
//            internal object countryname;
//            internal int id;

//            public string country { get; set; }
//        }
//    }
//}
