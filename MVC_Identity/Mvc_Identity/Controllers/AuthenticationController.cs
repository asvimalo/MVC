using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Mvc_Identity.EF;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mvc_Identity.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<IdentityUser> userManager;
        public AuthenticationController()
        {
            var context = new MyIdentityDbContext();
            var store = new UserStore<IdentityUser>(context);
            userManager = new UserManager<IdentityUser>(store);

        }

        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string Password)
        {
            //Starta fill first
            var user = await userManager.FindAsync(UserName, Password);
            if (user == null) return View();

            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(identity);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string userName, string password, string email)
        {
            //set up user
            var user = new IdentityUser
            {
                UserName = userName,
                Email = email
            };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                identity.AddClaim(new Claim("Genre","Male"));

                var authenticationManager = HttpContext.GetOwinContext().Authentication;

                authenticationManager.SignIn(identity);
                

            }
            return RedirectToAction("Index", "Home"); 
        }
    }
}