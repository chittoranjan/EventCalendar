using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventCalenderApp.Context;
using EventCalenderApp.Models;
using EventCalenderApp.Models.ViewModels;

namespace EventCalenderApp.Controllers
{
    
    public class HomeController : Controller
    {
        ContextManager db = new ContextManager();
        public ActionResult Index()
        {
            return View();
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