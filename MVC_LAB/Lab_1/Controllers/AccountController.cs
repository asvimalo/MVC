using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using LAB_DAL.Repo;
using Lab_1.Models;
using Lab_1.HelperClasses;

namespace Lab_1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Loggin
        private UserRepo userRepo;
        public AccountController()
        {
            userRepo = new UserRepo();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            if (!ModelState.IsValid)
                return PartialView(user);

            var dbUser = new LoginModel();
            dbUser.MapUser(userRepo.GetUserAuth(user.Email, user.Password));
            if (dbUser.Email != null && dbUser.Password != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, dbUser.Name),
                    new Claim(ClaimTypes.Email, dbUser.Email),
                    new Claim(ClaimTypes.Role, dbUser.isAdmin ? "Admin" : "User"),
                    new Claim(ClaimTypes.NameIdentifier, dbUser.UserID.ToString()),
                }, "AppCookie");

                var context = Request.GetOwinContext();
                var auth = context.Authentication;
                auth.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }
            return PartialView(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                userRepo.Add(user.MapUser());
            }
            else
            {
                ModelState.AddModelError("", "Missing information");
                return PartialView(user);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var auth = context.Authentication;

            auth.SignOut("AppCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}