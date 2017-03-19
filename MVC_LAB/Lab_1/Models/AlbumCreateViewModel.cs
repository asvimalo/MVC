using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class AlbumCreateViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Creator { get; set; }
    }
}