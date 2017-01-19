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
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PhotoID { get; set; }
        [ForeignKey("PhotoID")]
        public Photo Photo { get; set; }
        public virtual ICollection<Photo> PhotoAlbum { get; set; } 
        public Album()
        {
            PhotoAlbum = new HashSet<Photo>();
        }
    }
}
