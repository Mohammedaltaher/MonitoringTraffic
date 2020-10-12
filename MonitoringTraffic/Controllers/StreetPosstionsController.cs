using MonitoringTraffic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringTraffic.Controllers
{
    public class StreetPosstionsController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.ddlStreet = db.Street.Where(ac => ac.IsDeleted != "Y").ToList();
            var StreetPosstions = db.StreetPosstions.ToList();
            return View(StreetPosstions);
        }
        [HttpPost]
        public JsonResult GetStreetPosstionsList()
        {
            try
            {
                var StreetPosstionsList = db.StreetPosstions.Where(c => c.IsDeleted != "Y").Select(a => new
                {
                    a.Id,
                    a.Latitude  ,
                    a.Longitude,
                    a.Name,
                    StreetName = a.Street.Name,
                }).ToList();

                return Json(StreetPosstionsList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(1);
            }
        }

        public JsonResult BindStreetPosstions(int id)
        {
            try
            {
                // int ID = int.Parse(id);

                var StreetPosstions = db.StreetPosstions.Where(c => c.Id == id).Select(a => new
                {
                    a.Id,
                    a.Latitude,
                    a.Longitude,
                    a.Name,
                    a.StreetID

                });
                return Json(StreetPosstions, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0);
            }
        }
        [HttpPost]
        public JsonResult AddStreetPosstions(StreetPosstions StreetPosstions)
        {
            try
            {
                StreetPosstions.IsDeleted = "N";
                db.StreetPosstions.Add(StreetPosstions);
                db.SaveChanges();
                return Json(new { code = 1 });
            }
            catch (DbEntityValidationException )
            {
                //foreach (var eve in e.EntityValidationErrors)
                //{
                //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //            ve.PropertyName, ve.ErrorMessage);
                //    }
                //}
                return Json(new { code = 0 });
                // throw;
            }

        }
        [HttpPost]
        public ActionResult EditStreetPosstions(StreetPosstions StreetPosstions)
        {
            try
            {
                var inDB = db.StreetPosstions.SingleOrDefault(B => B.Id == StreetPosstions.Id);
                inDB.Longitude = StreetPosstions.Longitude;
                inDB.Latitude = StreetPosstions.Latitude;
                inDB.StreetID = StreetPosstions.StreetID;
                inDB.IsDeleted = "N" ;
                inDB.Name = StreetPosstions.Name;
                db.SaveChanges();
                return Json(new { code = 1 });
            }
            catch (Exception)
            {
                return Json(new { code = 0 });
            }
        }
        [HttpPost]
        public ActionResult DeleteStreetPosstions(int id)
        {
            try
            {
                var inDB = db.StreetPosstions.SingleOrDefault(B => B.Id == id);
                if (inDB != null)
                {
                    inDB.IsDeleted = "Y";
                    db.SaveChanges();
                    return Json(new { code = 1 });
                }
                return Json(new { code = 0 });
            }
            catch
            {
                return Json(new { code = 0 });
            }
        }
    }
}