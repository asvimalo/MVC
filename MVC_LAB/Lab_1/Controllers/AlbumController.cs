using LAB_DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        private PhotoRepository photoRepo;
        private CommentRepo commentRepo;

        public AlbumController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}