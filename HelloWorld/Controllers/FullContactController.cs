using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Infrastructure;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace HelloWorld.Controllers
{
    public class FullContactController : Controller
    {
        private FullContactService service = new FullContactService();

        // GET: FullContact
        public ActionResult Index()
        {
            return View();
        }

        // GET: FullContact/Create
        public ActionResult Info(string email)
        {
            string response = service.GetFullContactAsync(email);
            var obj = JObject.Parse(response);
            var status = (string)obj["status"];

            if (status.Equals("200"))
            {
                ViewBag.IsFound = true;
                ViewBag.Email = email;
                ViewBag.Type = (string)obj["socialProfiles"][0]["type"];
                ViewBag.TypeId = (string)obj["socialProfiles"][0]["typeId"];
                ViewBag.TypeName = (string)obj["socialProfiles"][0]["typeName"];
                ViewBag.Url = (string)obj["socialProfiles"][0]["url"];
                ViewBag.Username = (string)obj["socialProfiles"][0]["username"];
                ViewBag.Id = (string)obj["socialProfiles"][0]["id"];
            }
            else
            {
                ViewBag.IsFound = false;
            }

            return View();
        }
    }
}