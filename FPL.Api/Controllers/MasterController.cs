using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
//using static FPL.Bal.adarsh.Class2;

namespace FPL.Api.Controllers
{
    public class MasterController : ApiController
       
    {
        //private fileuploadEntities db = new fileuploadEntities();

        //private object c;
        ////Roll master
        //[HttpPost]
        //public IHttpActionResult Save(abc savedata)
        //{
        //    Rollmaster data = new Rollmaster()
        //    {
        //        RoleName = savedata.RoleName,
        //        Createdon = savedata.Createdon,
        //        Createdby = savedata.Createdby,
        //    };


        //    db.Rollmasters.Add(data);
        //    db.SaveChanges();

        //    return Ok("success");
        //}


        //[HttpGet]
        //public IHttpActionResult Getalldata()
        //{
        //    var res = db.Rollmasters.ToList();
        //    return Ok(res);
        //}

        //[HttpGet]
        //public async Task<IHttpActionResult> Deletedata([FromUri(Name ="id")] int id)
        //{

        //    var data = await Task.Run(() => db.Rollmasters.FindAsync(id));
        //    await Task.Run(() => db.Rollmasters.Remove(data));
        //   await db.SaveChangesAsync();

        //    return Ok("success");
        //}

        ////place master
        //[HttpPost]
        //public async Task<IHttpActionResult> save1(abc savedata1)
        //{
        //    Placemaster data = new Placemaster()
        //    {
        //        Address = savedata1.Address,
        //        City = savedata1.City,
        //        State = savedata1.State,
        //        Country = savedata1.Country,
        //        Pincode = savedata1.Pincode,
        //        Createdby = savedata1.Createdby,
        //    };


        //    db.Placemasters.Add(data);
        //    db.SaveChanges();

        //    return Ok("success");
        //}


        //[HttpGet]
        //public IHttpActionResult Getalldata1()
        //{
        //    var res = db.Placemasters.ToList();
        //    return Ok(res);
        //}

        //[HttpGet]
        //public async Task<IHttpActionResult> Deletedata1([FromUri(Name = "id")] int id)
        //{

        //    var data = await Task.Run(() => db.Placemasters.FindAsync(id));
        //    await Task.Run(() => db.Placemasters.Remove(data));
        //    await db.SaveChangesAsync();

        //    return Ok("success");
        //}

        ////user master
        //[HttpPost]
        //public async Task<IHttpActionResult> save2(abc savedata2)
        //{
        //    Usermaster data = new Usermaster()
        //    {
        //        Firstname = savedata2.Firstname,
        //        Lastname = savedata2.Lastname,
        //        Email = savedata2.Email,
        //        Phno = savedata2.Phno,
        //        Designation = savedata2.Designation,
        //        Gender = savedata2.Gender,
        //        Dob = savedata2.Dob
        //    };


        //    db.Usermasters.Add(data);
        //    db.SaveChanges();

        //    return Ok("success");
        //}


        //[HttpGet]
        //public IHttpActionResult Getalldata2()
        //{
        //    var res = db.Usermasters.ToList();
        //    return Ok(res);
        //}

        //[HttpGet]
        //public async Task<IHttpActionResult> Deletedata2([FromUri(Name = "id")] int id)
        //{
        //    var data = await Task.Run(() => db.Usermasters.FindAsync(id));
        //    await Task.Run(() => db.Usermasters.Remove(data));
        //    await db.SaveChangesAsync();
        //    return Ok("success");
        //}
    }
}
