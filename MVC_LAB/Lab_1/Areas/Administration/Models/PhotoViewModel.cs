using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Areas.Administration.Models
{
    public class PhotoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime DateAdded { get; set; }
        public string Uploader { get; set; }
        public string Album { get; set; }
    }
}