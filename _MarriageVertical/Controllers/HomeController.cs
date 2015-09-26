using _MarriageVertical.BusinessLogic.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _MarriageVertical.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.name = TestBLL.getNameAge()[0].Name;
            return View();
        }

    }
}
