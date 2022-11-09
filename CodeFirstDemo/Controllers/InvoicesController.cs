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
    public class InvoicesController : Controller
    {
        private CodeFirtDemoEntities1 db = new CodeFirtDemoEntities1();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.InvoiceDetails).Include(i => i.Products).Include(i => i.Sellers);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return HttpNotFound();
            }
            return View(invoices);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceDetail_InvoiceDetailID = new SelectList(db.InvoiceDetails, "InvoiceDetailID", "CantProd");
            ViewBag.Product_ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.Seller_SellerID = new SelectList(db.Sellers, "SellerID", "Name");
            return View();
        }

        // POST: Invoices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,Date,InvoiceNumber,InvoiceDetail_InvoiceDetailID,Product_ProductID,Seller_SellerID")] Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceDetail_InvoiceDetailID = new SelectList(db.InvoiceDetails, "InvoiceDetailID", "CantProd", invoices.InvoiceDetail_InvoiceDetailID);
            ViewBag.Product_ProductID = new SelectList(db.Products, "ProductID", "Name", invoices.Product_ProductID);
            ViewBag.Seller_SellerID = new SelectList(db.Sellers, "SellerID", "Name", invoices.Seller_SellerID);
            return View(invoices);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceDetail_InvoiceDetailID = new SelectList(db.InvoiceDetails, "InvoiceDetailID", "CantProd", invoices.InvoiceDetail_InvoiceDetailID);
            ViewBag.Product_ProductID = new SelectList(db.Products, "ProductID", "Name", invoices.Product_ProductID);
            ViewBag.Seller_SellerID = new SelectList(db.Sellers, "SellerID", "Name", invoices.Seller_SellerID);
            return View(invoices);
        }

        // POST: Invoices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,Date,InvoiceNumber,InvoiceDetail_InvoiceDetailID,Product_ProductID,Seller_SellerID")] Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceDetail_InvoiceDetailID = new SelectList(db.InvoiceDetails, "InvoiceDetailID", "CantProd", invoices.InvoiceDetail_InvoiceDetailID);
            ViewBag.Product_ProductID = new SelectList(db.Products, "ProductID", "Name", invoices.Product_ProductID);
            ViewBag.Seller_SellerID = new SelectList(db.Sellers, "SellerID", "Name", invoices.Seller_SellerID);
            return View(invoices);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return HttpNotFound();
            }
            return View(invoices);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoices invoices = db.Invoices.Find(id);
            db.Invoices.Remove(invoices);
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
