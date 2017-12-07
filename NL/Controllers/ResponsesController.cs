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
    public class ResponsesController : Controller
    {
        private NLcontext db = new NLcontext();

        // GET: Responses
        public ActionResult Index()
        {
            var responses = db.Responses.Include(r => r.Question).Include(r => r.User);
            return View(responses.ToList());
        }

        // GET: Responses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // GET: Responses/Create
        public ActionResult Create()
        {
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QuestionDesc");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName");
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponseID,UserID,QuestionID,ResponseDesc")] Response response)
        {
            if (ModelState.IsValid)
            {
                response.ResponseID = db.Responses.Max(r => r.ResponseID) + 1;
                db.Responses.Add(response);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QuestionDesc", response.QuestionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName", response.UserID);
            return View(response);
        }

        // GET: Responses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QuestionDesc", response.QuestionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName", response.UserID);
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponseID,UserID,QuestionID,ResponseDesc")] Response response)
        {
            if (ModelState.IsValid)
            {
                db.Entry(response).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "QuestionDesc", response.QuestionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName", response.UserID);
            return View(response);
        }

        // GET: Responses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Response response = db.Responses.Find(id);
            db.Responses.Remove(response);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
