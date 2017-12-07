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
    public class CompoundsController : Controller
    {
        private NLcontext db = new NLcontext();

        // GET: Compounds
        public ActionResult Index()
        {
            var compounds = db.Compounds.Include(c => c.User).Include(c => c.WorkOrder);
            return View(compounds.ToList());
        }

        // GET: Compounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

        // GET: Compounds/Create
        public ActionResult Create()
        {
            ViewBag.ReceivedBy = new SelectList(db.Users, "UserId", "UserFirstName");
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "Description");
            return View();
        }

        // POST: Compounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderID,Name,ActualAmount_mg,StatedAmount_mg,MolecularMass,DateArrived,ReceivedBy,Appearance")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                compound.LTNum = db.Compounds.Max(c => c.LTNum) + 1;
                db.Compounds.Add(compound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceivedBy = new SelectList(db.Users, "UserId", "UserFirstName", compound.ReceivedBy);
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "Description", compound.WorkOrderID);
            return View(compound);
        }

        // GET: Compounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceivedBy = new SelectList(db.Users, "UserId", "UserFirstName", compound.ReceivedBy);
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "Description", compound.WorkOrderID);
            return View(compound);
        }

        // POST: Compounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LTNum,WorkOrderID,Name,ActualAmount_mg,StatedAmount_mg,MolecularMass,DateArrived,ReceivedBy,Appearance")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceivedBy = new SelectList(db.Users, "UserId", "UserFirstName", compound.ReceivedBy);
            ViewBag.WorkOrderID = new SelectList(db.WorkOrders, "WorkOrderID", "Description", compound.WorkOrderID);
            return View(compound);
        }

        // GET: Compounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

        // POST: Compounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compound compound = db.Compounds.Find(id);
            db.Compounds.Remove(compound);
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
