using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class UserModelView
    {
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Required Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [EmailAddress(ErrorMessage ="A valid email address is needed")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^.*(?=.*[!@#$%^&*\(\)_\-+=]).*$")]
        [Required(ErrorMessage = "Required Password")]
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        
    }
}