using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Identity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            var identity = User.Identity as ClaimsIdentity;
            var name = identity.FindFirst("name").Value;
            
            return Content($"You are login as: {name}");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserName, string Password)
        {
            //Starta fill first
            return View();
        }
        public ActionResult Logout(string UserName, string Password)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //Starta fill first
            return RedirectToAction("Login");
        }
    }
}