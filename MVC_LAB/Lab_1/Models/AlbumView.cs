using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class AlbumView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<PhotoView> MyPhotos { get; set; }
        public AlbumView()
        {
            MyPhotos = new List<PhotoView>();
        }
    }
}