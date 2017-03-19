using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Lab_1.Areas.Administration.Models;
using LAB_DAL.EF;
using System.IO;
using System.Net;
using WebGrease.Css.Extensions;

namespace Lab_1.Areas.Administration.Controllers
{
    public class ManagementController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            using (var db = new GalleryEntities())
            {
                

                var data = new IndexViewModel();

                db.Albums.ToList().ForEach(x => data.AlbumViewModels.Add(new AlbumViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }));

                db.Comments.Include("User").Include("Photo").ToList().ForEach(x => data.CommentViewModels.Add(new CommentViewModel
                {
                    Id = x.Id,
                    Commenter = x.User.Name,
                    Comment = x.Text,
                    Date = x.Date,
                    PhotoName = x.Photo.Name
                }));

                db.Photos.Include("User").Include("Album").ToList().ForEach(x => data.PhotoViewModels.Add(new PhotoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FileName = x.FileName,
                    Album = x.Album.Name,
                    Uploader = x.User.Name,
                    Description = x.Description,
                    DateAdded = x.DateAdded
                }));

                db.Users.ToList().ForEach(x => data.UserViewModels.Add(new UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                }));

                return View(data);
            }
        }

        public ActionResult ListUsers()
        {
            var users = new List<UserViewModel>();

            using (var db = new GalleryEntities())
            {
                db.Users.ToList().ForEach(x => users.Add(new UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                }));
            }

            return PartialView(users);
        }

        [Authorize]
        public ActionResult UploadPhoto(UploadPhotoViewModel model)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult UploadPhoto(UploadPhotoViewModel model, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
                return View(model);

            photo.SaveAs(Path.Combine(Server.MapPath("~/Photos"), photo.FileName));
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DeleteComment(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            using (var db = new GalleryEntities())
            {
                var comment = db.Comments.Include(i => i.Photo).FirstOrDefault(x => x.Id == id);
                return comment == null ? (ActionResult)HttpNotFound() : View(comment);
            }
        }

        [Authorize]
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(Guid id)
        {
            using (var db = new GalleryEntities())
            {
                var comment = db.Comments.Include(i => i.Photo).FirstOrDefault(x => x.Id == id);
                db.Comments.Remove(comment);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
