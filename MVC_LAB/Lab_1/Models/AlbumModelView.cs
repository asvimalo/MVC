using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab_1.Models
{
    public class AlbumModelView
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Album's name is requiered")]
        [Display(Name = "Album's Name")]
        public string AlbumName { get; set; }
        [Display(Name ="Date Created")]
        public DateTime DateCreated { get; set; }
        public Guid UserID { get; set; }

        public UserModelView User { get; set; }
        public virtual ICollection<PhotoViewModel> MyPhotos { get; set; }
        public AlbumModelView()
        {
            MyPhotos = new HashSet<PhotoViewModel>();
        }
    }


}