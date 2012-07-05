using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Controllers
{ 
    public class NewsController : Controller
    {
        private BlogContext _db = new BlogContext();

        //
        // GET: /News/
        public ViewResult Index()
        {
            var viewResult = View(_db.Posts.ToList().OrderByDescending(p => p.Updated));
            return viewResult; //View(_db.Posts.ToList());s
        }

        //
        // GET: /News/Details/5
        public ViewResult Details(int id)
        {
            Post post = _db.Posts.Find(id);
            return View(post);
        }

        //
        // GET: /News/Create
        [Authorize(Roles = "Blogger")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /News/Create

        [HttpPost, Authorize(Roles="Blogger")]
        public ActionResult Create(Post post)
        {
            post.UserName = User.Identity.Name;
            post.Updated = DateTime.UtcNow;

            if (ModelState.IsValid)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(post);
        }
        
        //
        // GET: /News/Edit/5

        [Authorize(Roles = "Blogger")]
        public ActionResult Edit(int id)
        {
            Post post = _db.Posts.Find(id);
            return View(post);
        }

        //
        // POST: /News/Edit/5

        [HttpPost, Authorize(Roles="Blogger")]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(post).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /News/Delete/5
        [Authorize(Roles = "Blogger")]
        public ActionResult Delete(int id)
        {
            Post post = _db.Posts.Find(id);
            return View(post);
        }

        //
        // POST: /News/Delete/
        [HttpPost, ActionName("Delete"), Authorize(Roles="Blogger")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Post post = _db.Posts.Find(id);
            _db.Posts.Remove(post);
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