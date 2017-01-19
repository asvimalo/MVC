using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_DAL.Models
{
    [Table("User")]
    public class User
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

        public User()
        {
            Albums = new HashSet<Album>();
            Comments = new HashSet<Comment>();
            Photos = new HashSet<Photo>();
        }

    }
}
