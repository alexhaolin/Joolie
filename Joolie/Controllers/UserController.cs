using Joolie.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Joolie.Controllers
{
    public class UserController : Controller
    {
        JoolieDB db = new JoolieDB();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Joolie.Models.Login user)
        {
            System.Diagnostics.Debug.WriteLine("User Login Controller starting...");
            bool hasErrors = ViewData.ModelState.Values.Any(x => x.Errors.Count > 1);
            System.Diagnostics.Debug.WriteLine("Has errors? " + hasErrors);
            if (ModelState.IsValid)
            {
                if (user.IsValid(_username: user.UserName, _password: user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("SearchPage", "Search");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        public JsonResult SaveData(User u)
        {
            Console.WriteLine("[SaveData] Saving data to databse...");
            try
            {
                db.Users.Add(u);
                db.SaveChanges();
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
           
            return Json("Registration Successful.", JsonRequestBehavior.AllowGet);
        }


    }
}

