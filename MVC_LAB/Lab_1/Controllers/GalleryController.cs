using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using Lab_1.EF;
using System.IO;
using LAB_DAL.EF;
using LAB_DAL.Repo;
using LAB_DAL.Models;
using Lab_1.HelperClasses;

namespace Lab_1.Controllers
{
    public class GalleryController : Controller
    {
        private PhotoRepository photoRepository;
        private CommentRepo commentRepository;

        public GalleryController()
        {
            photoRepository = new PhotoRepository();
            commentRepository = new CommentRepo();
        }

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var photos = new List<GalleryPhotoViewModel>();
            photos.MapPhotos(photoRepository.GetItems().ToList());

            return View(photos);
        }

        [AllowAnonymous]
        public ActionResult Details(DetailsPhotoViewModel photo)
        {
            var picture = photoRepository.FindById(photo.Id);
            photo.MapPhoto(picture);

            return View(photo);
        }

        [HttpGet]
        [Authorize]
        public ActionResult UploadPhoto()
        {
            
            var photo = new GalleryPhotoViewModel();
            var albums = AlbumRepo.GetAlbumsByUserId(UserRepo.GetUserId(User.Identity.Name));
            albums.ForEach(x => photo.Albums.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));

            return PartialView(photo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPhoto(GalleryPhotoViewModel model, HttpPostedFileBase photo)
        {
            
            if (!ModelState.IsValid)
                return PartialView(model);

            photoRepository.Add(model.MapPhoto(photo.FileName, UserRepo.GetUserId(User.Identity.Name)));

            photo.SaveAs(Path.Combine(Server.MapPath("~/Photos"), photo.FileName));
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Comments(ICollection<CommentViewModel> comments)
        {
            return PartialView(comments);
        }

        [HttpGet]
        public ActionResult AddComment(GalleryPhotoViewModel model)
        {
            var comment = new CommentViewModel { PhotoId = model.Id };

            return PartialView(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel model)
        {
            model.Commenter = User.Identity.Name;
            commentRepository.Add(model.MapComment());

            var photo = new DetailsPhotoViewModel();
            var picture = photoRepository.FindById(model.PhotoId);
            photo.MapPhoto(picture);

            return PartialView("Comments", photo.Comments);
        }
    }
}