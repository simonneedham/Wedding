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
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(); ;
            //return View("News", _db.Posts.ToList());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
