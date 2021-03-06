﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Areas.wedding.Controllers
{ 
    public class NewsController : Controller
    {
        private BlogContext _db = new BlogContext();

        //
        // GET: /News/
        [CompressFilter]
        public ViewResult Index()
        {
            var viewResult = View(_db.Posts.ToList().OrderByDescending(p => p.Updated));
            return viewResult;
        }

        //
        // GET: /News/Details/5
        [CompressFilter]
        public ViewResult Details(int id)
        {
            Post post = _db.Posts.Where(p => p.PostId == id).Include(p => p.Tags).SingleOrDefault();
            return View(post);
        }

        //
        // GET: /News/Create
        [CompressFilter]
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

            if(post.Updated == null)
                post.Updated = post.Updated.ToUniversalTime();

            if (post.Updated.Kind == DateTimeKind.Local)
                post.Updated = post.Updated.ToUniversalTime();

            if (ModelState.IsValid)
            {
                foreach (var tag in post.Tags.ToList())
                {
                    var dbTag = _db.Tags.Where(t => t.Name.ToLower() == tag.Name.ToLower()).SingleOrDefault();
                    {
                        post.Tags.Remove(tag);
                        post.Tags.Add(dbTag);
                    }
                }

                _db.Posts.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }
        
        //
        // GET: /News/Edit/5
        [CompressFilter]
        [Authorize(Roles = "Blogger")]
        public ActionResult Edit(int id)
        {
            Post post = _db.Posts.Find(id);
            return View(post);
        }

        //
        // POST: /News/Edit/5
        [CompressFilter]
        [HttpPost, Authorize(Roles="Blogger")]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                if(post.Updated == null)
                    post.Updated = DateTime.UtcNow;

                if (post.Updated.Kind == DateTimeKind.Local)
                    post.Updated = post.Updated.ToUniversalTime();

                var databasePost = _db.Posts.Where(p => p.PostId == post.PostId).Include(p => p.Tags).SingleOrDefault();
                _db.Entry(databasePost).CurrentValues.SetValues(post);

                //append new tags
                foreach (var updatedTag in post.Tags)
                {
                    var dbTag = databasePost.Tags.Where(t => t.Name == updatedTag.Name).SingleOrDefault();

                    if (dbTag == null)
                    {
                        //New Tag not associated with post
                        dbTag = _db.Tags.Where(t => t.Name == updatedTag.Name).SingleOrDefault();

                        if (dbTag == null)
                            dbTag = new Tag() { Name = updatedTag.Name };

                        databasePost.Tags.Add(dbTag);
                    }
                }

                //remove tags
                foreach (var dbTag in databasePost.Tags.ToList())
                {
                    var updatedTag = post.Tags.Where(t => t.Name == dbTag.Name).SingleOrDefault();

                    if (updatedTag == null)
                        databasePost.Tags.Remove(dbTag);
                }

                _db.Entry(databasePost).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /News/Delete/5
        [CompressFilter]
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