using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TabletCollection.DAL;
using TabletCollection.Models;
using TabletCollection.ViewModels;

namespace TabletCollection.Controllers.api
{
    public class TabletsController : ApiController
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        // GET: api/Tablets
        public IEnumerable<TabletViewModel> GetTablets()
        {
            var tablets = db.Tablets.OrderBy(t => t.TabletName).ToList();

            var tabletViewModels = Mapper.Map<List<TabletViewModel>>(tablets);
            return tabletViewModels;
            //return db.Tablets;
        }

        // GET: api/Tablets/5
        [ResponseType(typeof(Tablet))]
        public IHttpActionResult GetTablet(int id)
        {
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return NotFound();
            }

            return Ok(tablet);
        }

        // PUT: api/Tablets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTablet(int id, Tablet tablet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tablet.ID)
            {
                return BadRequest();
            }

            db.Entry(tablet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabletExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tablets
        [ResponseType(typeof(Tablet))]
        public IHttpActionResult PostTablet(Tablet tablet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tablets.Add(tablet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tablet.ID }, tablet);
        }

        // DELETE: api/Tablets/5
        [ResponseType(typeof(Tablet))]
        public IHttpActionResult DeleteTablet(int id)
        {
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return NotFound();
            }

            db.Tablets.Remove(tablet);
            db.SaveChanges();

            return Ok(tablet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TabletExists(int id)
        {
            return db.Tablets.Count(e => e.ID == id) > 0;
        }
    }
}