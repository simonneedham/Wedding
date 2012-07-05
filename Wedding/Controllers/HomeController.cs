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

        public ActionResult Index()
        {
            //return View();
            return View("/Views/News/Index.cshtml", _db.Posts.ToList().OrderByDescending(p => p.Updated));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
