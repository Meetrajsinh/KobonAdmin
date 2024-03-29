﻿using System;
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
    public class GiftCardsController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: GiftCards
        public ActionResult Index()
        {
            return View(db.GiftCards.ToList());
        }

        // GET: GiftCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftCard giftCard = db.GiftCards.Find(id);
            if (giftCard == null)
            {
                return HttpNotFound();
            }
            return View(giftCard);
        }

        // GET: GiftCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiftCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GiftCardId,CompanyName,CompanyLogo,CardValidity,CardPrice,TermsAndConditions,Instructions")] GiftCard giftCard)
        {
            if (ModelState.IsValid)
            {
                db.GiftCards.Add(giftCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giftCard);
        }

        // GET: GiftCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftCard giftCard = db.GiftCards.Find(id);
            if (giftCard == null)
            {
                return HttpNotFound();
            }
            return View(giftCard);
        }

        // POST: GiftCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GiftCardId,CompanyName,CompanyLogo,CardValidity,CardPrice,TermsAndConditions,Instructions")] GiftCard giftCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giftCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giftCard);
        }

        // GET: GiftCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftCard giftCard = db.GiftCards.Find(id);
            if (giftCard == null)
            {
                return HttpNotFound();
            }
            return View(giftCard);
        }

        // POST: GiftCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiftCard giftCard = db.GiftCards.Find(id);
            db.GiftCards.Remove(giftCard);
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
