using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedding.Areas.wedding.Controllers
{
    public class HowToGetThereController : Controller
    {
        //
        // GET: /HowToGetThere/
        [CompressFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}
