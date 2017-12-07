using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NL.DAL;
using NL.Models;

namespace NL.Controllers
{
    public class HomeController : Controller
    {
        private NLcontext db = new NLcontext();

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

        public ActionResult Forum()
        {
            ViewBag.Message = "Post and answer questions and interact with our support staff.";

            ViewBag.Questions = db.Questions.ToList(); //creates list of question objects
            ViewBag.Responses = db.Responses.ToList(); //creates list of responses object
            ViewBag.Users = db.Users.ToList(); //creates list of users

            return View();
        }
    }
}