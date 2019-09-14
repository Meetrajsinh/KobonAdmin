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
    public class NotificationSettingsController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: NotificationSettings
        public ActionResult Index()
        {
            return View(db.NotificationSettings.ToList());
        }

        // GET: NotificationSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSetting notificationSetting = db.NotificationSettings.Find(id);
            if (notificationSetting == null)
            {
                return HttpNotFound();
            }
            return View(notificationSetting);
        }

        // GET: NotificationSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SettingId,RemainderOnClaimOffer,OffersMyLocation,NewsUpdatesOffer,CashbackOffers,CashbackReferrals,CashbackEarnedByReferrer,AccountId")] NotificationSetting notificationSetting)
        {
            if (ModelState.IsValid)
            {
                db.NotificationSettings.Add(notificationSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notificationSetting);
        }

        // GET: NotificationSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSetting notificationSetting = db.NotificationSettings.Find(id);
            if (notificationSetting == null)
            {
                return HttpNotFound();
            }
            return View(notificationSetting);
        }

        // POST: NotificationSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SettingId,RemainderOnClaimOffer,OffersMyLocation,NewsUpdatesOffer,CashbackOffers,CashbackReferrals,CashbackEarnedByReferrer,AccountId")] NotificationSetting notificationSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificationSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notificationSetting);
        }

        // GET: NotificationSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSetting notificationSetting = db.NotificationSettings.Find(id);
            if (notificationSetting == null)
            {
                return HttpNotFound();
            }
            return View(notificationSetting);
        }

        // POST: NotificationSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotificationSetting notificationSetting = db.NotificationSettings.Find(id);
            db.NotificationSettings.Remove(notificationSetting);
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
