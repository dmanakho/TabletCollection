using AutoMapper;
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
using TabletCollection.ViewModels;

namespace TabletCollection.Controllers
{
    public class TabletsController : Controller
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        // GET: Tablets
        public ActionResult Index(bool filter = false)
        {
            var tablets = from t in db.Tablets select t;
            if (filter)
            {
                var collectedTabletsIDs = db.Collections
                    .Select(s => s.TabletID);
                tablets = tablets.Where(s => !collectedTabletsIDs.Contains(s.ID));
            }
            tablets = tablets.OrderBy(t=>t.TabletName);
            var tabletViewModels = Mapper.Map<List<TabletViewModel>>(tablets);
            //get collections IDs only when we display all tablets
            if (!filter)
            {
                tabletViewModels.ForEach(t => t.CollectionID = db.Collections.Where(c => c.TabletID == t.ID).Select(c => c.Id).FirstOrDefault());
                tabletViewModels.ForEach(t => t.IsTabletCollected = (t.CollectionID > 0) ? true : false);
            }
            //this is to show extra column in extra view for Collected tablets if all tablets are shown. Need to find a better solution perhaps.
            ViewBag.Filter = filter;
            //this line is to correctly set non-sorting column in DataTable.
            ViewBag.ExtraColumn = filter ? 8 : 9;
            return View(tabletViewModels);
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
            var tabletViewModel = Mapper.Map<Tablet>(tablet);
            return View(tabletViewModel);
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
        public ActionResult Create(TabletViewModel tabletViewModel)
        {
            if (ModelState.IsValid)
            {
                var tablet = Mapper.Map<Tablet>(tabletViewModel);
                db.Tablets.Add(tablet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabletViewModel);
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

            var tabletViewModel = Mapper.Map<TabletViewModel>(tablet);
            return View(tabletViewModel);
        }

        // POST: Tablets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TabletViewModel tabletViewModel)
        {
            if (ModelState.IsValid)
            {
                var tablet = Mapper.Map<Tablet>(tabletViewModel);

                db.Entry(tablet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabletViewModel);
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

        public ActionResult BulkEdit()
        {
            var tablets = db.Tablets.OrderBy(t => t.TabletName).ToList();

            var tabletViewModels = Mapper.Map<List<TabletViewModel>>(tablets);
            return View(tabletViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkEdit(IList<TabletViewModel> tabletsViewModel)
        {
            if (ModelState.IsValid)
            {
                var tablets = Mapper.Map<IList<Tablet>>(tabletsViewModel);

                foreach (var tablet in tablets)
                {
                    db.Entry(tablet).State = EntityState.Modified;
                   
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabletsViewModel);
        }

        public JsonResult BulkEditJsonStream()
        {
            var tablets = db.Tablets.OrderBy(t => t.TabletName).ToList();

            var tabletViewModels = Mapper.Map<List<TabletViewModel>>(tablets);
            return Json(tabletViewModels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BulkEditJson()
        {
            var tablets = db.Tablets.OrderBy(t => t.TabletName).ToList();

            var tabletViewModels = Mapper.Map<List<TabletViewModel>>(tablets);
            return View(tabletViewModels);
        }

        public ActionResult BulkEditPg()
        {
            var tablets = db.Tablets.OrderBy(t => t.TabletName).ToList();

            var tabletViewModels = Mapper.Map<List<TabletViewModel>>(tablets);
            return View(tabletViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BulkEditPg(IList<TabletViewModel> tabletsViewModel)
        {
            if (ModelState.IsValid)
            {
                var tablets = Mapper.Map<IList<Tablet>>(tabletsViewModel);

                foreach (var tablet in tablets)
                {
                    db.Entry(tablet).State = EntityState.Modified;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabletsViewModel);
        }
    }
}
