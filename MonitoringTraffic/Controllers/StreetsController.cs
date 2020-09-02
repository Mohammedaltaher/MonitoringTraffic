using MonitoringTraffic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringTraffic.Controllers
{
    public class StreetsController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.ddlCity = db.City.Where(ac => ac.IsDeleted != "Y").ToList();
            var street = db.Street.ToList();
            return View(street);
        }
        [HttpPost]
        public JsonResult GetStreetsList()
        {
            try
            {
                var streetList = db.Street.Where(c => c.IsDeleted != "Y").Select(a => new
                {
                    a.Id,
                    a.Name  ,
                    CityName = a.City.Name
                }).ToList();

                return Json(streetList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(1);
            }
        }

        public JsonResult BindStreets(int id)
        {
            try
            {
                // int ID = int.Parse(id);

                var street = db.Street.Where(c => c.Id == id).Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.CityID

                });
                return Json(street, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0);
            }
        }
        [HttpPost]
        public JsonResult AddStreets(Street street)
        {
            try
            {
                street.IsDeleted = "N";
                db.Street.Add(street);
                db.SaveChanges();
                return Json(new { code = 1 });
            }
            catch (DbEntityValidationException e)
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
        public ActionResult EditStreets(Street street)
        {
            try
            {
                var inDB = db.Street.SingleOrDefault(B => B.Id == street.Id);
                inDB.Name = street.Name;
                inDB.CityID = street.CityID;
                inDB.IsDeleted = "N" ;
                db.SaveChanges();
                return Json(new { code = 1 });
            }
            catch (Exception)
            {
                return Json(new { code = 0 });
            }
        }
        [HttpPost]
        public ActionResult DeleteStreets(int id)
        {
            try
            {
                var inDB = db.Street.SingleOrDefault(B => B.Id == id);
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