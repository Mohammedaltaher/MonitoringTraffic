using MonitoringTraffic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringTraffic.Controllers
{
    public class CamerasController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.ddlStreet = db.Street.Where(ac => ac.IsDeleted != "Y").ToList();
            var camera = db.Camera.ToList();
            return View(camera);
        }
        [HttpPost]
        public JsonResult GetCamerasList()
        {
            try
            {
                var cameraList = db.Camera.Where(c => c.IsDeleted != "Y").Select(a => new
                {
                    a.Id,
                    a.IpAddress  ,
                    a.Pin,
                    StreetName = a.Street.Name,
                    CityName = a.Street.City.Name
                }).ToList();

                return Json(cameraList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(1);
            }
        }

        public JsonResult BindCameras(int id)
        {
            try
            {
                // int ID = int.Parse(id);

                var camera = db.Camera.Where(c => c.Id == id).Select(a => new
                {
                    a.Id,
                    a.IpAddress,
                    a.Pin,
                    a.StreetID

                });
                return Json(camera, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0);
            }
        }
        [HttpPost]
        public JsonResult AddCameras(Camera camera)
        {
            try
            {
                camera.IsDeleted = "N";
                db.Camera.Add(camera);
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
        public ActionResult EditCameras(Camera camera)
        {
            try
            {
                var inDB = db.Camera.SingleOrDefault(B => B.Id == camera.Id);
                inDB.IpAddress = camera.IpAddress;
                inDB.Pin = camera.Pin;
                inDB.StreetID = camera.StreetID;
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
        public ActionResult DeleteCameras(int id)
        {
            try
            {
                var inDB = db.Camera.SingleOrDefault(B => B.Id == id);
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