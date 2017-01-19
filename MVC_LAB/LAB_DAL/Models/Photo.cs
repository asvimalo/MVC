using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LAB_DAL.Models
{
    [Table("Photo")]
    public class Photo
    {
        public Guid PhotoID { get; set; }
        
        public string Path { get; set; } //Path or FileName
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public Nullable<DateTime> UploadedDate { get; set; }
        public Nullable<DateTime> DateChanged { get; set; }

        public virtual Guid UserID { get; set; }
        public virtual Guid AlbumID { get; set; }
        [ForeignKey("AlbumID")]
        public virtual Album Album { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }



        public Photo()
        {
            
            Comments = new HashSet<Comment>();
        }
    }
}
