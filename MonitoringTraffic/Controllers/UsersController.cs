using MonitoringTraffic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitoringTraffic.Controllers
{
    public class UsersController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.ddlUserType = db.UserType.Where(ac => ac.IsDeleted != "Y").ToList();
            var User = db.User.ToList();
            return View(User);
        }
        [HttpPost]
        public JsonResult GetUsersList()
        {
            try
            {
                var UserList = db.User.Where(c => c.IsDeleted != "Y").Select(a => new
                {
                    a.Id,
                    a.FullName,
                    a.Username  ,
                    a.UserTypeId ,
                    a.Email  ,
                    a.Password  ,
                    a.PhoneNumber  ,
                    UserTypeName = a.UserType.Name
                }).ToList();

                return Json(UserList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(1);
            }
        }

        public JsonResult BindUsers(int id)
        {
            try
            {
                // int ID = int.Parse(id);

                var User = db.User.Where(c => c.Id == id).Select(a => new
                {
                    a.Id,
                    a.FullName,
                    a.Username,
                    a.UserTypeId,
                    a.Email,
                    a.Password,
                    a.PhoneNumber

                });
                return Json(User, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0);
            }
        }
        [HttpPost]
        public JsonResult AddUsers(User User)
        {
            try
            {
                User.IsDeleted = "N";
                db.User.Add(User);
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
        public ActionResult EditUsers(User User)
        {
            try
            {
                var inDB = db.User.SingleOrDefault(B => B.Id == User.Id);
                inDB.FullName = User.FullName;
                inDB.PhoneNumber = User.PhoneNumber;
                inDB.Email = User.Email;
                inDB.Password = User.Password;
                inDB.UserTypeId = User.UserTypeId;
                inDB.Username = User.Username;
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
        public ActionResult DeleteUsers(int id)
        {
            try
            {
                var inDB = db.User.SingleOrDefault(B => B.Id == id);
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