using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Models
{
    public class GalleryPhotoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public Guid? AlbumId { get; set; }
        public string UploadedBy { get; set; }

        public ICollection<SelectListItem> Albums { get; set; }

        public GalleryPhotoViewModel()
        {
            Albums = new List<SelectListItem>();
        }
    }
}