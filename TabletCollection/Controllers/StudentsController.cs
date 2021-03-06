﻿using System;
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

namespace TabletCollection.Controllers
{
    public class StudentsController : Controller
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        // GET: Students
        public ActionResult Index(bool filter = true)
        {
            var students = from s in db.Students select s;

            if (filter)
            {
                var collectedStudentIDs = db.Collections
                    .Select(s => s.StudentID);
                students = students.Where(s => !collectedStudentIDs.Contains(s.ID));
            }
            students = students.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
            
            var studentsViewModel = Mapper.Map<List<StudentViewModel>>(students.ToList());
            return View(studentsViewModel);
        }

        [ChildActionOnly]
        public ActionResult _StudentsPartial()
        {
            var students = from s in db.Students select s;
            var collectedStudentIDs = db.Collections
                    .Select(s => s.StudentID);
            students = students
                .Where(s => !collectedStudentIDs.Contains(s.ID))
                .OrderBy(s => s.FirstName).ThenBy(s => s.LastName); ;
            var studentsViewModel = Mapper.Map<List<StudentViewModel>>(students.ToList());
            return PartialView(studentsViewModel);
        }

        // GET: Students/Details/5
        //public ActionResult Details(int? id)
        //{
        //    //not implemented dont need dont care
        //    //if (id == null)
        //    //{
        //    //    return new httpstatuscoderesult(httpstatuscode.badrequest);
        //    //}
        //    //student student = db.students.find(id);
        //    //if (student == null)
        //    //{
        //    //    return httpnotfound();
        //    //}
        //    //return view(student);
        //}

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            
            if (ModelState.IsValid)
            {
                db.Students.Add(Mapper.Map<Student>(studentViewModel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentViewModel);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImportID,FirstName,NickName,LastName,UserName,ForeignExchangeBound,ClassOf, Notes")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
