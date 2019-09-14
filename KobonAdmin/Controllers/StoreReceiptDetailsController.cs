using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KobonAdmin.Models;

namespace KobonAdmin.Controllers
{
    public class StoreReceiptDetailsController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: StoreReceiptDetails
        public ActionResult Index()
        {
            return View(db.StoreReceiptDetails.ToList());
        }

        // GET: StoreReceiptDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreReceiptDetail storeReceiptDetail = db.StoreReceiptDetails.Find(id);
            if (storeReceiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(storeReceiptDetail);
        }

        // GET: StoreReceiptDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreReceiptDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreReceiptId,TypeOfStore,Fields")] StoreReceiptDetail storeReceiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.StoreReceiptDetails.Add(storeReceiptDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeReceiptDetail);
        }

        // GET: StoreReceiptDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreReceiptDetail storeReceiptDetail = db.StoreReceiptDetails.Find(id);
            if (storeReceiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(storeReceiptDetail);
        }

        // POST: StoreReceiptDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreReceiptId,TypeOfStore,Fields")] StoreReceiptDetail storeReceiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeReceiptDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeReceiptDetail);
        }

        // GET: StoreReceiptDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreReceiptDetail storeReceiptDetail = db.StoreReceiptDetails.Find(id);
            if (storeReceiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(storeReceiptDetail);
        }

        // POST: StoreReceiptDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoreReceiptDetail storeReceiptDetail = db.StoreReceiptDetails.Find(id);
            db.StoreReceiptDetails.Remove(storeReceiptDetail);
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
