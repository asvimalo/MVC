using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_DAL.Models
{
    [Table("Album")]
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual ICollection<Photo> PhotoAlbum { get; set; } 
        public Album()
        {
            PhotoAlbum = new HashSet<Photo>();
        }
    }
}
