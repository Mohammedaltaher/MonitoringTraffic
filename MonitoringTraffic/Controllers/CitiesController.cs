using MonitoringTraffic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringTraffic.Controllers
{
    public class CitiesController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var city = db.City.ToList();
            return View(city);
        } 
        [HttpPost]
        public JsonResult GetCitiesList()
        {
            try
            {
                var cityList = db.City.Where(c => c.IsDeleted != "Y").Select(a => new
                {
                    a.Id,
                    a.Name 
                }).ToList();

                return Json(cityList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(1);
            }
        }

        public JsonResult BindCities(int id)
        {
            try
            {
                // int ID = int.Parse(id);

                var city = db.City.Where(c => c.Id == id).Select(a => new
                {
                    a.Id,
                    a.Name

                });
                return Json(city, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0);
            }
        }
        [HttpPost]
        public JsonResult AddCities(City city)
        {
            try
            {
                city.IsDeleted = "N";
                db.City.Add(city);
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
        public ActionResult EditCities(City city)
        {
            try
            {
                var inDB = db.City.SingleOrDefault(B => B.Id == city.Id);
                inDB.Name = city.Name;
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
        public ActionResult DeleteCities(int id)
        {
            try
            {
                var inDB = db.City.SingleOrDefault(B => B.Id == id);
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