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
    public class ClaimOffersController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: ClaimOffers
        public ActionResult Index()
        {
            return View(db.ClaimOffers.ToList());
        }

        // GET: ClaimOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaimOffer claimOffer = db.ClaimOffers.Find(id);
            if (claimOffer == null)
            {
                return HttpNotFound();
            }
            return View(claimOffer);
        }

        // GET: ClaimOffers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaimOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaimOfferId,CashBackAmount,StartTimeOfClaiming,EndTimeOfClaiming,ClaimingDate,ClaimingStatus,OfferId,AccountId")] ClaimOffer claimOffer)
        {
            if (ModelState.IsValid)
            {
                db.ClaimOffers.Add(claimOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claimOffer);
        }

        // GET: ClaimOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaimOffer claimOffer = db.ClaimOffers.Find(id);
            if (claimOffer == null)
            {
                return HttpNotFound();
            }
            return View(claimOffer);
        }

        // POST: ClaimOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaimOfferId,CashBackAmount,StartTimeOfClaiming,EndTimeOfClaiming,ClaimingDate,ClaimingStatus,OfferId,AccountId")] ClaimOffer claimOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claimOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claimOffer);
        }

        // GET: ClaimOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaimOffer claimOffer = db.ClaimOffers.Find(id);
            if (claimOffer == null)
            {
                return HttpNotFound();
            }
            return View(claimOffer);
        }

        // POST: ClaimOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaimOffer claimOffer = db.ClaimOffers.Find(id);
            db.ClaimOffers.Remove(claimOffer);
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
