using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Northwest Labs was founded on strong principles of integrity and high-quality service. We value our customers and look for every opportunity to help their companies succeed.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out to us through email, phone, or stop by our office with any inquiries or requests.";

            return View();
        }
    }
}