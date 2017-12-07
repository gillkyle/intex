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
    public class WorkOrdersController : Controller
    {
        private NLcontext db = new NLcontext();

        // GET: WorkOrders
        public ActionResult Index()
        {
            var workOrders = db.WorkOrders.Include(w => w.BillDetail).Include(w => w.Priority).Include(w => w.Status).Include(w => w.User);
            return View(workOrders.ToList());
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            ViewBag.BillID = new SelectList(db.BillDetails, "BillID", "BillFirstName");
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "Description");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusDescription");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderID,BillID,UserID,StatusID,StartTime,EndTime,EarlyDate,DueDate,Description,PriorityID,TotalQuote,ActualPrice,AdvanceAmtPaid,ConfirmationDate")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillID = new SelectList(db.BillDetails, "BillID", "BillFirstName", workOrder.BillID);
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "Description", workOrder.PriorityID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusDescription", workOrder.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName", workOrder.UserID);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillID = new SelectList(db.BillDetails, "BillID", "BillFirstName", workOrder.BillID);
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "Description", workOrder.PriorityID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusDescription", workOrder.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName", workOrder.UserID);
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOrderID,BillID,UserID,StatusID,StartTime,EndTime,EarlyDate,DueDate,Description,PriorityID,TotalQuote,ActualPrice,AdvanceAmtPaid,ConfirmationDate")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillID = new SelectList(db.BillDetails, "BillID", "BillFirstName", workOrder.BillID);
            ViewBag.PriorityID = new SelectList(db.Priorities, "PriorityID", "Description", workOrder.PriorityID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusDescription", workOrder.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserFirstName", workOrder.UserID);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            db.WorkOrders.Remove(workOrder);
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
