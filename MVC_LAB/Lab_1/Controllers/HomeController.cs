using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.EF;

namespace Lab_1.Controllers
{
    public class HomeController : Controller
    {
        private Gallery _gallery = new Gallery();
        // GET: Home
        public ActionResult Index()
        {
            return View(_gallery);
        }
    }
}