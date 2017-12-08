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
    public class SampleAssaysController : Controller
    {
        private NLcontext db = new NLcontext();

        // GET: SampleAssays
        public ActionResult Index()
        {
            var sampleAssays = db.SampleAssays.Include(s => s.Assay).Include(s => s.Sample);
            return View(sampleAssays.ToList());
        }

        // GET: SampleAssays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleAssay sampleAssay = db.SampleAssays.Find(id);
            if (sampleAssay == null)
            {
                return HttpNotFound();
            }
            return View(sampleAssay);
        }

        // GET: SampleAssays/Create
        public ActionResult Create()
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc");
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleID");
            return View();
        }

        // POST: SampleAssays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SampleID,AssayID,Comment")] SampleAssay sampleAssay)
        {
            if (ModelState.IsValid)
            {
                db.SampleAssays.Add(sampleAssay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", sampleAssay.AssayID);
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleID", sampleAssay.SampleID);
            return View(sampleAssay);
        }

        // GET: SampleAssays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleAssay sampleAssay = db.SampleAssays.Find(id);
            if (sampleAssay == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", sampleAssay.AssayID);
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleID", sampleAssay.SampleID);
            return View(sampleAssay);
        }

        // POST: SampleAssays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SampleID,AssayID,Comment")] SampleAssay sampleAssay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sampleAssay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", sampleAssay.AssayID);
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleID", sampleAssay.SampleID);
            return View(sampleAssay);
        }

        // GET: SampleAssays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleAssay sampleAssay = db.SampleAssays.Find(id);
            if (sampleAssay == null)
            {
                return HttpNotFound();
            }
            return View(sampleAssay);
        }

        // POST: SampleAssays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleAssay sampleAssay = db.SampleAssays.Find(id);
            db.SampleAssays.Remove(sampleAssay);
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
