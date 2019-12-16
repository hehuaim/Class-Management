using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var siteInfo = new WebsiteInfo("Demo", "RIGHT");
            ViewBag.SiteInfo = siteInfo;

            ViewData["SiteInfo"] = siteInfo;

            return View(siteInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}