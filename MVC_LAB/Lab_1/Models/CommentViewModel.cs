using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_1.Models
{
    public class CommentViewModel
    {
        public int ComID { get; set; }
        [Required(ErrorMessage ="Requiered to enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Required to enter a comment")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public Guid PhotoID { get; set; }
        public Guid UserID { get; set; }

        public PhotoViewModel Photo { get; set; }
        public UserModelView User { get; set; }
    }
}