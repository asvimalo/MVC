using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Areas.Administration.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string WriterComment { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string PhotoName { get; set; }
        public PhotoViewModel Photo { get; set; }
        public UserViewModel User { get; set; }
    }
}