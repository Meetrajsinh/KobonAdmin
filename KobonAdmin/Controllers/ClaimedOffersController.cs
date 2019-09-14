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
    public class ClaimedOffersController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: ClaimedOffers
        public ActionResult Index()
        {
            return View(db.ClaimedOffers.ToList());
        }

        // GET: ClaimedOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaimedOffer claimedOffer = db.ClaimedOffers.Find(id);
            if (claimedOffer == null)
            {
                return HttpNotFound();
            }
            return View(claimedOffer);
        }

        // GET: ClaimedOffers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaimedOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaimedId,ClaimedTime,ClaimedDate,ReceiptId,ClaimOfferId")] ClaimedOffer claimedOffer)
        {
            if (ModelState.IsValid)
            {
                db.ClaimedOffers.Add(claimedOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claimedOffer);
        }

        // GET: ClaimedOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaimedOffer claimedOffer = db.ClaimedOffers.Find(id);
            if (claimedOffer == null)
            {
                return HttpNotFound();
            }
            return View(claimedOffer);
        }

        // POST: ClaimedOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaimedId,ClaimedTime,ClaimedDate,ReceiptId,ClaimOfferId")] ClaimedOffer claimedOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claimedOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claimedOffer);
        }

        // GET: ClaimedOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaimedOffer claimedOffer = db.ClaimedOffers.Find(id);
            if (claimedOffer == null)
            {
                return HttpNotFound();
            }
            return View(claimedOffer);
        }

        // POST: ClaimedOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaimedOffer claimedOffer = db.ClaimedOffers.Find(id);
            db.ClaimedOffers.Remove(claimedOffer);
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
