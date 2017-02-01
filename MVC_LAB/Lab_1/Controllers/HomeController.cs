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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //private Gallery _gallery = new Gallery();
        // GET: Home
        private PhotoRepository repo { get; set; }

        public HomeController()
        {
            repo = new PhotoRepository();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var recentUploadedPics = new List<PhotoViewModel>();
            var recentUploadedDB = PhotoRepository.GetLastPicturesUploaded();
            foreach (var photo in recentUploadedDB)
            {
                recentUploadedPics.Add(ModelViewToModelData.ReturnPhotoModelView(photo));
            }

            return View(recentUploadedPics); //_gallery
        }

    }
}