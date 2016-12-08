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
        [StringLength(50)]
        public string Path { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        
        
        public DateTime UploadedDate { get; set; }
        
        
        
        public Photo()
        {
            
            PhotoID = Guid.NewGuid();
        }
    }
}
