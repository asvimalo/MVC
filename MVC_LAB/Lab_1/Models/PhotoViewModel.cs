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
        [Display(Name="Posted")]
        public DateTime? UploadedDate { get; set; }
        [Display(Name="Edited")]
        public DateTime? DateChanged { get; set; }
        [Required]
        [Display(Name="Public")]
        public bool IsPublicPicture { get; set; }
        public Guid UserID { get; set; }
        public Guid? GalleryID { get; set; }
        public string UserUploaderPhoto { get; set; }



    }
}