using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TabletCollection.DAL;
using TabletCollection.Models;

namespace TabletCollection.Controllers
{
    public class TabletsController : Controller
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        // GET: Tablets
        public ActionResult Index()
        {
            return View(db.Tablets.ToList());
        }

        // GET: Tablets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return HttpNotFound();
            }
            return View(tablet);
        }

        // GET: Tablets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tablets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TabletName,SerialNo,AssetTag,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,RowVersion")] Tablet tablet)
        {
            if (ModelState.IsValid)
            {
                db.Tablets.Add(tablet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablet);
        }

        // GET: Tablets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return HttpNotFound();
            }
            return View(tablet);
        }

        // POST: Tablets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TabletName,SerialNo,AssetTag,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,RowVersion")] Tablet tablet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablet);
        }

        // GET: Tablets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return HttpNotFound();
            }
            return View(tablet);
        }

        // POST: Tablets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tablet tablet = db.Tablets.Find(id);
            db.Tablets.Remove(tablet);
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
