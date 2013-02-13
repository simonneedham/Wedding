using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedding.Controllers
{
    public class WhereToStayController : Controller
    {
        //
        // GET: /WhereToStay/
        [CompressFilter]
        public ActionResult Index()
        {
            return View();
        }

    }
}
