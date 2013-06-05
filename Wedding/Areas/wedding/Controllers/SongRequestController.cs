using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding.Models;
using System.Data;

namespace Wedding.Areas.wedding.Controllers
{
    public class SongRequestController : Controller
    {
        private BlogContext _db = new BlogContext();

        //
        // GET: /wedding/Rsvp/
        [CompressFilter]
        public ViewResult Index()
        {
            var songs = _db.SongRequests.OrderBy(sr => sr.ArtistName).ThenBy(sr => sr.SongName).ToList();
            return View(songs);
        }

        //
        // GET: /wedding/Rsvp/Details/5
        [CompressFilter]
        public ViewResult Details(int id)
        {
            var sr = _db.SongRequests.Find(id);
            return View(sr);
        }

        //
        // GET: /wedding/Rsvp/Create
        [CompressFilter]
        public ActionResult Create()
        {
            var sr = new SongRequest();
            sr.IPAddress = Request.ServerVariables["REMOTE_ADDR"];
            return View(sr);
        }

        //
        // POST: /wedding/Rsvp/Create
        [HttpPost]
        public ActionResult Create(SongRequest songRequest)
        {
            if (String.IsNullOrEmpty(songRequest.ArtistName) && String.IsNullOrEmpty(songRequest.SongName))
                ModelState.AddModelError("SongName", "Hmmm you've got to give us at least an artist or a song name");

            if (ModelState.IsValid)
            {
                songRequest.Updated = DateTime.UtcNow;
                _db.SongRequests.Add(songRequest);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(songRequest);
        }

        //
        // GET: /wedding/Rsvp/Edit/5
        [CompressFilter, Authorize(Roles = "Blogger")]
        public ActionResult Edit(int id)
        {
            var sr = _db.SongRequests.Find(id);
            return View(sr);
        }

        //
        // POST: /wedding/Rsvp/Edit/5
        [HttpPost, Authorize(Roles = "Blogger")]
        public ActionResult Edit(SongRequest songRequest)
        {
            if (ModelState.IsValid)
            {
                songRequest.Updated = DateTime.UtcNow;
                _db.Entry(songRequest).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(songRequest);
        }

        //
        // GET: /wedding/Rsvp/Delete/5
        [CompressFilter, Authorize(Roles = "Blogger")]
        public ActionResult Delete(int id)
        {
            var sr = _db.SongRequests.Find(id);
            return View(sr);
        }

        //
        // POST: /wedding/Rsvp/Delete/5
        [HttpPost, ActionName("Delete"), Authorize(Roles = "Blogger")]
        public ActionResult DeleteConfirmed(int id)
        {
            var sr = _db.SongRequests.Find(id);
            _db.SongRequests.Remove(sr);
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