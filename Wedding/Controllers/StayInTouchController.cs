using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedding.Controllers
{
    public class StayInTouchController : Controller
    {
        //
        // GET: /StayInTouch/
        [CompressFilter]
        public ActionResult Index()
        {
            return View();
        }

    }
}
