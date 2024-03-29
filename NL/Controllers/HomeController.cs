﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NL.DAL;
using NL.Models;
using Microsoft.AspNet.Identity;

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
        [Authorize]
        public ActionResult Forum()
        {
            string userEmail = User.Identity.GetUserName();
            if (userEmail != "")
            {
                int userID = db.Database.SqlQuery<int>(
                      "SELECT TOP 1 UserId " +
                      "FROM [User] " +
                      "WHERE UserEmail = '" + userEmail + "'").First<int>();
                ViewBag.userID = userID;
            }
                ViewBag.Message = "Post and answer questions and interact with our support staff.";

            ViewBag.Questions = db.Questions.ToList(); //creates list of question objects
            ViewBag.Responses = db.Responses.ToList(); //creates list of responses object
            ViewBag.Users = db.Users.ToList(); //creates list of users

            return View();
        }

        public ActionResult Catalog()
        {
            ViewBag.Message = "Read about some of the many different tests we run.";

            ViewBag.Assays = db.Assays.ToList();
            ViewBag.AssayReferences = db.AssayReferences.ToList();

            return View();
        }

        [Authorize]
        public ActionResult MyOrders()
        {
            string userEmail = User.Identity.GetUserName();
            if (userEmail != "")
            {
                int userID = db.Database.SqlQuery<int>(
                      "SELECT TOP 1 UserId " +
                      "FROM [User] " +
                      "WHERE UserEmail = '" + userEmail + "'").First<int>();
                ViewBag.userID = userID;

                var userFullName= db.Database.SqlQuery<String>(
                      "SELECT TOP 1 UserFirstName + ' ' + UserLastName " +
                      "FROM [User] " +
                      "WHERE UserEmail = '" + userEmail + "'").First<String>();
                ViewBag.userFullName = userFullName;
            }


            ViewBag.Message = "You have no orders to display.";

            ViewBag.Orders = db.Database.SqlQuery<WorkOrder>(
                "SELECT * " +
                "FROM [WorkOrder] " +
                "INNER JOIN [Status] ON [Status].StatusID = WorkOrder.StatusID " +
                "WHERE UserID = " + ViewBag.userID);

            ViewBag.Compounds = db.Database.SqlQuery<Compound>(
                "SELECT * " +
                "FROM [Compound] ");

            ViewBag.Users = db.Users.ToList(); //creates list of users
            ViewBag.Statuses = db.Status.ToList();
            //ViewBag.Compounds = db.Compounds.ToList();
            //ViewBag.Orders = db.WorkOrders.ToList();

            return View();
        }
    }
}