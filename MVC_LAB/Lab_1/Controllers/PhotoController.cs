using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB_DAL.Repo;
using System.ComponentModel.DataAnnotations;

namespace Lab_1.Controllers
{
    [AllowAnonymous]
    public class PhotoController : Controller
    {
        PhotoRepository repo = new PhotoRepository();
        // GET: Photo
        public ActionResult Index()
        {
            return View();
        }
    }
}