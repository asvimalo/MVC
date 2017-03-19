using Kunskapkoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Kunskapkoll.Controllers
{
    public class AddressBookController : Controller
    {
        public static List<Person> posts = new List<Person>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(posts);
        }

        [HttpGet]
        public ActionResult List(List<Person> model)
        {
            return PartialView(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView(new Person());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person post)
        {
            post.Id = Guid.NewGuid();
            post.Added = DateTime.Now;
            posts.Add(post);

            return PartialView("List", posts);
        }

        [HttpGet]
        public ActionResult Edit(Person model)
        {
            var post = posts.Find(x => x.Id == model.Id);
            return PartialView(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person model, FormCollection collection)
        {
            var addressPost = posts.Find(x => x.Id == model.Id);
            posts.Remove(addressPost);
            model.Changed = DateTime.Now;
            posts.Add(model);

            return PartialView("List", posts);
        }

        [HttpPost]
        public ActionResult Delete(Person model)
        {
            var addressPost = posts.Find(x => x.Id == model.Id);
            posts.Remove(addressPost);

            return PartialView("List", posts);
        }
    }
}