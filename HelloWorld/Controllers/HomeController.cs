using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница с описанием.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница с контактными данными.";

            return View();
        }

        public ActionResult Art()
        {
            ViewBag.Message = "Художественная галерея.";

            return View();
        }
    }
}