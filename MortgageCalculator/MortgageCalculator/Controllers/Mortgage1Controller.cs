using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MortgageCalculator.Models;


namespace MortgageCalculator.Controllers
{
    public class Mortgage1Controller : Controller
    {
        private MortgageDBEntities db = new MortgageDBEntities();

        // GET: Mortgage1
        public ActionResult Index()
        {
            return View(db.Mortgage1.ToList());
        }

        // GET: Mortgage1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mortgage1 mortgage1 = db.Mortgage1.Find(id);
            if (mortgage1 == null)
            {
                return HttpNotFound();
            }
            return View(mortgage1);
        }

        // GET: Mortgage1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mortgage1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Principle,Rate,Years,MonthlyPayment")] Mortgage1 mortgage1)
        {
            if (ModelState.IsValid)
            {
                double prin = Convert.ToDouble(mortgage1.Principle);
                double ys = Convert.ToDouble(mortgage1.Years);
                double rat = Convert.ToDouble(mortgage1.Rate);
                ViewBag.CalculateTemp = MortgageCalc.CalcMonthlyPayment(prin,rat,ys);
                //ViewBag.Msg = $"The Monthly Payment is {ViewBag.CalculateTemp}";
                string output = string.Format("Monthly Payment is {0:C}", ViewBag.CalculateTemp);
                mortgage1.MonthlyPayment = output;

                db.Mortgage1.Add(mortgage1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mortgage1);
        }

        // GET: Mortgage1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mortgage1 mortgage1 = db.Mortgage1.Find(id);
            if (mortgage1 == null)
            {
                return HttpNotFound();
            }
            return View(mortgage1);
        }

        // POST: Mortgage1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Principle,Rate,Years,MonthlyPayment")] Mortgage1 mortgage1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mortgage1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mortgage1);
        }

        // GET: Mortgage1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mortgage1 mortgage1 = db.Mortgage1.Find(id);
            if (mortgage1 == null)
            {
                return HttpNotFound();
            }
            return View(mortgage1);
        }

        // POST: Mortgage1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mortgage1 mortgage1 = db.Mortgage1.Find(id);
            db.Mortgage1.Remove(mortgage1);
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
