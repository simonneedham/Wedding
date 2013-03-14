using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Areas.wedding.Controllers
{ 
    public class RsvpController : Controller
    {
        private BlogContext _db = new BlogContext();

        //
        // GET: /wedding/Rsvp/
        [Authorize(Roles = "Blogger")]
        [CompressFilter]
        public ViewResult Index()
        {
            return View(_db.Rsvp.ToList());
        }

        //
        // GET: /wedding/Rsvp/Details/5
        [CompressFilter]
        [Authorize(Roles = "Blogger")]
        public ViewResult Details(int id)
        {
            Rsvp rsvp = _db.Rsvp.Find(id);
            return View(rsvp);
        }

        //
        // GET: /wedding/Rsvp/Create
        [CompressFilter]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /wedding/Rsvp/Create
        [HttpPost]
        public ActionResult Create(Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                _db.Rsvp.Add(rsvp);
                _db.SaveChanges();
                return View("Received", rsvp);  
            }

            return View(rsvp);
        }

        [CompressFilter]
        public ActionResult Received(Rsvp rsvp)
        {
            return View(rsvp);
        }

        //
        // GET: /wedding/Rsvp/Edit/5
        [CompressFilter]
        [Authorize(Roles = "Blogger")]
        public ActionResult Edit(int id)
        {
            Rsvp rsvp = _db.Rsvp.Find(id);
            return View(rsvp);
        }

        //
        // POST: /wedding/Rsvp/Edit/5
        [HttpPost]
        [Authorize(Roles = "Blogger")]
        public ActionResult Edit(Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(rsvp).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rsvp);
        }

        //
        // GET: /wedding/Rsvp/Delete/5
        [CompressFilter]
        [Authorize(Roles = "Blogger")]
        public ActionResult Delete(int id)
        {
            Rsvp rsvp = _db.Rsvp.Find(id);
            return View(rsvp);
        }

        //
        // POST: /wedding/Rsvp/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Rsvp rsvp = _db.Rsvp.Find(id);
            _db.Rsvp.Remove(rsvp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}