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
        public Guid Id { get; set; }
        [Required]
        public string Commenter { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Guid PhotoId { get; set; }

    }
}