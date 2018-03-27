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
using AutoMapper;
using System.Data.Entity.Infrastructure;

namespace TabletCollection.Controllers
{
    public class CollectionsController : Controller
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        // GET: Collections
        public ActionResult Index()
        {
            var collections = db.Collections.ToList();
            var collectionsViewModel = Mapper.Map<List<CollectionViewModel>>(collections);
            return View(collectionsViewModel);
        }

        // GET: Collections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return HttpNotFound();
            }
            var collectionViewModel = Mapper.Map<CollectionViewModel>(collection);
            return View(collectionViewModel);
        }

        // GET: Collections/Create
        public ActionResult Create(int? studentID)
        {
            if (!studentID.HasValue)
            {
                return RedirectToAction("Index", "Students", null);
            }

            var collectionViewModel = new CollectionViewModel(studentID.Value);

            var checkIfCollected = db.Collections.Where(t => t.TabletID == collectionViewModel.TabletID).FirstOrDefault();

            if (!(checkIfCollected == null))
            {
                collectionViewModel.Comments = $"Uh-Oh! Something went wrong!<br /> " +
                    $"The tablet is shown as collected. Conflicting collection ID: {checkIfCollected.Id}";
            }
            //viewbag will populate the drop down. I need "tablets" variable to limit the drop down to the tablets that weren't collected yet.
            var collectedTabletsIDs = db.Collections.Select(s => s.TabletID);
            var tablets = db.Tablets.Where(s => !collectedTabletsIDs.Contains(s.ID)).ToList();
            ViewBag.TabletID = new SelectList(tablets, "ID", "TabletName", collectionViewModel.TabletID);

            return View(collectionViewModel);
        }

        // POST: Collections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollectionViewModel collectionViewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var collection = Mapper.Map<Collection>(collectionViewModel);
                    db.Collections.Add(collection);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Students");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, $"Database Error occured Copy the error message and send it to Dima</br>: {dex.Message}. / {dex.InnerException.Message} / {dex.InnerException.InnerException.Message} ");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error occured Copy the error message and send it to Dima</br>: {ex.Message}. + {ex.InnerException.Message} + {ex.InnerException.InnerException.Message}");
            }
            ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName", collectionViewModel.TabletID);
            return View(collectionViewModel);
        }

        // GET: Collections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return HttpNotFound();
            }
            var collectionViewModel = Mapper.Map<CollectionViewModel>(collection);
            //viewbag will populate the drop down. I need "tablets" variable to limit the drop down to the tablets that weren't collected yet.
            var collectedTabletsIDs = db.Collections.Where(t=>t.TabletID != collection.TabletID).Select(s => s.TabletID);
            var tablets = db.Tablets.Where(t => !collectedTabletsIDs.Contains(t.ID)).ToList();
            ViewBag.TabletID = new SelectList(tablets, "ID", "TabletName", collectionViewModel.TabletID);
            
            return View(collectionViewModel);
        }

        // POST: Collections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CollectionViewModel collectionViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var collection = Mapper.Map<Collection>(collectionViewModel);
                    db.Entry(collection).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                //This is implemented by a virtue of having "RowVersion" field in our model and database. watch this video for details: https://youtu.be/Gi_kEbc5faQ
                ModelState.AddModelError(string.Empty, $"The record you've been trying to update was modified by another user. Please go back and try again.");
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, $"Database Error occured Copy the error message and send it to Dima </br>: {dex.Message}. + {dex.InnerException.Message} + {dex.InnerException.InnerException.Message}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unexpected error occured. Copy the error message and send it to Dima {ex.Message} | {ex.InnerException.InnerException.Message}" +
                    $"{ex.InnerException.InnerException.Message}");
            }

            ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName", collectionViewModel.TabletID);
            return View(collectionViewModel);
        }

        // GET: Collections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return HttpNotFound();
            }
            var collectionViewModel = Mapper.Map<CollectionViewModel>(collection);
            return View(collectionViewModel);
        }

        // POST: Collections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collection collection = db.Collections.Find(id);
            db.Collections.Remove(collection);
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
