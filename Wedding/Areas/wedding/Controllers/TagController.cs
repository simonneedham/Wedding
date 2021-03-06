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
    public class TagController : Controller
    {
        private BlogContext _db = new BlogContext();

        //
        // GET: /Tag/
        [CompressFilter]
        public ViewResult Index()
        {
            return View(_db.Tags.OrderBy(t => t.Name));
        }

        //
        //GET: /tag/cloud
        [CompressFilter]
        public ViewResult Cloud()
        {
            var tags = _db.Tags.Include(t => t.Posts).OrderBy(t => t.Name);
            return View(tags);
        }

        //
        // GET: /Tag/{TagName}
        [CompressFilter]
        public ViewResult Posts(string tagName)
        {
            var posts = _db.Tags.Where(t => t.Name == tagName).SelectMany(t => t.Posts);

            if (posts != null)
                posts = posts.OrderByDescending(p => p.Updated);

            return View("/Areas/wedding/Views/News/Index.cshtml", posts);
        }

        //
        // GET: /Tag/Details/5
        [CompressFilter]
        public ViewResult Details(int id)
        {
            Tag tag = _db.Tags.Find(id);
            return View(tag);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}