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

namespace Lab_1.Controllers
{
    public class GalleryController : Controller
    {
        PhotoRepository repo = new PhotoRepository();
        //public static string Data { get; set; }
        //public ActionResult Show(int id, string meta)
        //{
        //    if (string.IsNullOrWhiteSpace(Data)) 
        //    {
        //        Data = meta;
        //    }
        //    return Content(Data);
        //}

        //public List<Photo> Gallery { get; set; } = new List<Photo>();
        // GET: Gallery

        public ActionResult Index()
        {
            return View(repo.All());

        }
        public ActionResult Upload()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, PhotoViewModel model)
        {
            

            if (!ModelState.IsValid) { return View(model); }
            if (file == null)
            {
                ModelState.AddModelError("error", "Ingen bild?");
                return View(model);
            }

            file.SaveAs(Path.Combine(Server.MapPath("~/Images"), file.FileName));
            var photo = new PhotoViewModel
            {
                PhotoID = Guid.NewGuid(),
                Name = model.Name,
                Path = "~/Images/" + file.FileName
            };

            repo.Add(new Photo
            {
                PhotoID = photo.PhotoID,
                Name = photo.Name,
                Path = photo.Path,
                UploadedDate = DateTime.Now
                
            });

            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            return View(repo.All());

        }
        public ActionResult Edit()
        {
            return View();

        }
    }
}