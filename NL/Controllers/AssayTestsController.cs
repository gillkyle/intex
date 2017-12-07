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

namespace NL.Controllers
{
    public class AssayTestsController : Controller
    {
        private NLcontext db = new NLcontext();

        // GET: AssayTests
        public ActionResult Index()
        {
            var assayTests = db.AssayTests.Include(a => a.Assay).Include(a => a.Test);
            return View(assayTests.ToList());
        }

        // GET: AssayTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayTest assayTest = db.AssayTests.Find(id);
            if (assayTest == null)
            {
                return HttpNotFound();
            }
            return View(assayTest);
        }

        // GET: AssayTests/Create
        public ActionResult Create()
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc");
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "Desc");
            return View();
        }

        // POST: AssayTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssayID,TestID,Active,Complete,Comment,Scheduled,Required,Approval,QuantResults,QualResults")] AssayTest assayTest)
        {
            if (ModelState.IsValid)
            {
                db.AssayTests.Add(assayTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", assayTest.AssayID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "Desc", assayTest.TestID);
            return View(assayTest);
        }

        // GET: AssayTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayTest assayTest = db.AssayTests.Find(id);
            if (assayTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", assayTest.AssayID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "Desc", assayTest.TestID);
            return View(assayTest);
        }

        // POST: AssayTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssayID,TestID,Active,Complete,Comment,Scheduled,Required,Approval,QuantResults,QualResults")] AssayTest assayTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assayTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", assayTest.AssayID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "Desc", assayTest.TestID);
            return View(assayTest);
        }

        // GET: AssayTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayTest assayTest = db.AssayTests.Find(id);
            if (assayTest == null)
            {
                return HttpNotFound();
            }
            return View(assayTest);
        }

        // POST: AssayTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssayTest assayTest = db.AssayTests.Find(id);
            db.AssayTests.Remove(assayTest);
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
