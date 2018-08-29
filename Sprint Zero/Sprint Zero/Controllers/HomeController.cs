using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Sprint_Zero.Models;

namespace Sprint_Zero.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
       
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

        public ActionResult Customer()
        {
            ViewBag.Message = "Your Customer page.";

            return View();
        }
      
    }
}