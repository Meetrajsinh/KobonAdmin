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
    public class AvailGiftCardsController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: AvailGiftCards
        public ActionResult Index()
        {
            return View(db.AvailGiftCards.ToList());
        }

        // GET: AvailGiftCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailGiftCard availGiftCard = db.AvailGiftCards.Find(id);
            if (availGiftCard == null)
            {
                return HttpNotFound();
            }
            return View(availGiftCard);
        }

        // GET: AvailGiftCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvailGiftCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvailGiftCardId,ClaimCode,ExpiryDate,Value,GiftCardStatus,UsedDate,WalletId,RequestId,AccountId")] AvailGiftCard availGiftCard)
        {
            if (ModelState.IsValid)
            {
                db.AvailGiftCards.Add(availGiftCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(availGiftCard);
        }

        // GET: AvailGiftCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailGiftCard availGiftCard = db.AvailGiftCards.Find(id);
            if (availGiftCard == null)
            {
                return HttpNotFound();
            }
            return View(availGiftCard);
        }

        // POST: AvailGiftCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvailGiftCardId,ClaimCode,ExpiryDate,Value,GiftCardStatus,UsedDate,WalletId,RequestId,AccountId")] AvailGiftCard availGiftCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availGiftCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(availGiftCard);
        }

        // GET: AvailGiftCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailGiftCard availGiftCard = db.AvailGiftCards.Find(id);
            if (availGiftCard == null)
            {
                return HttpNotFound();
            }
            return View(availGiftCard);
        }

        // POST: AvailGiftCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvailGiftCard availGiftCard = db.AvailGiftCards.Find(id);
            db.AvailGiftCards.Remove(availGiftCard);
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
