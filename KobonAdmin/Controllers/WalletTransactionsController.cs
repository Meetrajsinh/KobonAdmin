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
    public class WalletTransactionsController : Controller
    {
        private KobonModel db = new KobonModel();

        // GET: WalletTransactions
        public ActionResult Index()
        {
            return View(db.WalletTransactions.ToList());
        }

        // GET: WalletTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalletTransaction walletTransaction = db.WalletTransactions.Find(id);
            if (walletTransaction == null)
            {
                return HttpNotFound();
            }
            return View(walletTransaction);
        }

        // GET: WalletTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalletTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,TransactionType,TransactionDesc,Amount,TransactionDate,TransactionTime,WalletId")] WalletTransaction walletTransaction)
        {
            if (ModelState.IsValid)
            {
                db.WalletTransactions.Add(walletTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(walletTransaction);
        }

        // GET: WalletTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalletTransaction walletTransaction = db.WalletTransactions.Find(id);
            if (walletTransaction == null)
            {
                return HttpNotFound();
            }
            return View(walletTransaction);
        }

        // POST: WalletTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,TransactionType,TransactionDesc,Amount,TransactionDate,TransactionTime,WalletId")] WalletTransaction walletTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walletTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(walletTransaction);
        }

        // GET: WalletTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalletTransaction walletTransaction = db.WalletTransactions.Find(id);
            if (walletTransaction == null)
            {
                return HttpNotFound();
            }
            return View(walletTransaction);
        }

        // POST: WalletTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WalletTransaction walletTransaction = db.WalletTransactions.Find(id);
            db.WalletTransactions.Remove(walletTransaction);
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
