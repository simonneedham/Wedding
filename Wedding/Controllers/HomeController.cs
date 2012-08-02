using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding.Models;

namespace Wedding.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext _db = new BlogContext();

        [CompressFilter]
        public ActionResult Index()
        {
            //IEnumerable<Post> posts = _db.Posts.ToList();

            //if (posts != null)
            //    posts = posts.OrderByDescending(p => p.Updated).Take(1);


            var posts = _db.Posts.OrderByDescending(p => p.Updated).Take(1);
            return View("Index", posts);
        }

        [CompressFilter]
        public ActionResult About()
        {
            return View();
        }
    }
}
