using Joolie.Models;
using Joolie.ViewModels;
using System.Web.Mvc;

namespace Joolie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(fanProperties form)
        {
            //int p = form.MaxFirm;
            return View();
        }
        
        //public ActionResult About(FormCollection form)
        //{
        //    ViewBag.Message = "Your application description page.";

            
        //    foreach(var key in form.GetValues("ProductCheckbox"))
        //    {
        //       // var res = form.GetValue();
        //        System.Diagnostics.Debug.WriteLine(key);
        //    }
        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}