using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using Lab_1.EF;

namespace Lab_1.Controllers
{
    public class GalleryController : Controller
    {
        Gallery _gallery = new Gallery();
        
        //public List<Photo> Gallery { get; set; } = new List<Photo>();
        // GET: Gallery
        public ActionResult Index()
        {
            return View(_gallery.listOfPhotos);
        }
        public ViewResult Create()
        {
            return View();
        }
    }
}