using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB_DAL.EF;

namespace Lab_1.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            using (var context = new GalleryEntities())
            {
                var data = new IndexViewModel();
            }
        }
    }
}