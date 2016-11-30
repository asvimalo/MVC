using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class Photo
    {
        public Guid PhotoID { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime UploadedDate { get; set; }
    }
}