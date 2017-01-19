using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class PhotoViewModel
    {
        public Guid PhotoID { get; set; }
        public string Path { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a description")]
        [StringLength(50)]
        public string Description { get; set; }
        public DateTime? UploadedDate { get; set; }
        public DateTime? DateChanged { get; set; }

        public Guid? UserID { get; set; }
        public Guid? AlbumID { get; set; }
        public string UserUploaderPhoto { get; set; }



    }
}