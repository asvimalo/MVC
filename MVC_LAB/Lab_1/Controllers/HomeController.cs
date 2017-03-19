using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.EF;
using LAB_DAL.Repo;
using Lab_1.Models;
using Lab_1.HelperClasses;



namespace Lab_1.Controllers
{
    public class HomeController : Controller
    {
        private PhotoRepository PhotoRepository { get; set; }

        public HomeController()
        {
            PhotoRepository = new PhotoRepository();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var photo = new GalleryPhotoViewModel();
            photo.MapPhoto(PhotoRepository.GetLastUploadedPhoto());

            return View(photo);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Check our fantastic pictures";

            return View();
        }
    }
}