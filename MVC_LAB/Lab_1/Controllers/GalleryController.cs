using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using Lab_1.EF;
using System.IO;

namespace Lab_1.Controllers
{
    public class GalleryController : Controller
    {
        Gallery _gallery = new Gallery();
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
            return View(_gallery);
            
         }
        public ActionResult Upload()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, Photo model)
        {
            if (!ModelState.IsValid) { return View(model); }
            if(file == null)
            {
                ModelState.AddModelError("error", "Ingen bild?");
                return View(model);
            }

            file.SaveAs(Path.Combine(Server.MapPath("~/Images"), file.FileName));
            var photo = new Photo
            {
                PhotoID = Guid.NewGuid(),
                Name = model.Name,
                Path = Path.Combine(Server.MapPath("~/Images"), file.FileName)
            };
            _gallery.listOfPhotos.Add(photo);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            return View(_gallery.GetAll());

        }
    }
}