using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstDemo.Models;

namespace CodeFirstDemo.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private CodeFirtDemoEntities1 db = new CodeFirtDemoEntities1();

        // GET: InvoiceDetails
        public ActionResult Index()
        {
            return View(db.InvoiceDetails.ToList());
        }

        // GET: InvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceDetailID,CantProd,Local")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetails.Add(invoiceDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // POST: InvoiceDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceDetailID,CantProd,Local")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            db.InvoiceDetails.Remove(invoiceDetails);
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
