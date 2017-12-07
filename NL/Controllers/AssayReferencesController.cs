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
    public class AssayReferencesController : Controller
    {
        private NLcontext db = new NLcontext();

        // GET: AssayReferences
        public ActionResult Index()
        {
            var assayReferences = db.AssayReferences.Include(a => a.Assay);
            return View(assayReferences.ToList());
        }

        // GET: AssayReferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayReferences assayReferences = db.AssayReferences.Find(id);
            if (assayReferences == null)
            {
                return HttpNotFound();
            }
            return View(assayReferences);
        }

        // GET: AssayReferences/Create
        public ActionResult Create()
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc");
            return View();
        }

        // POST: AssayReferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RefID,AssayID,RefName,RefSource")] AssayReferences assayReferences)
        {
            if (ModelState.IsValid)
            {
                db.AssayReferences.Add(assayReferences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", assayReferences.AssayID);
            return View(assayReferences);
        }

        // GET: AssayReferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayReferences assayReferences = db.AssayReferences.Find(id);
            if (assayReferences == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", assayReferences.AssayID);
            return View(assayReferences);
        }

        // POST: AssayReferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RefID,AssayID,RefName,RefSource")] AssayReferences assayReferences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assayReferences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "Desc", assayReferences.AssayID);
            return View(assayReferences);
        }

        // GET: AssayReferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayReferences assayReferences = db.AssayReferences.Find(id);
            if (assayReferences == null)
            {
                return HttpNotFound();
            }
            return View(assayReferences);
        }

        // POST: AssayReferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssayReferences assayReferences = db.AssayReferences.Find(id);
            db.AssayReferences.Remove(assayReferences);
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
