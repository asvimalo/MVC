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
        List<Person> AddressBooks = new List<Person>();
        // GET: AddressBook
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            AddressBooks.Add(person);
            return List();
        }
        public ActionResult List()
        {
            
            return PartialView("ListAddress", AddressBooks);
        }
    }
}