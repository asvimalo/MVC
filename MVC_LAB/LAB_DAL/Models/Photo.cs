﻿using System;
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
        [Required]
        public Guid Id { get; set; }
        [ForeignKey("Id")]
        public virtual Album Album { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Photo()
        {
            Comments = new HashSet<Comment>();
            PhotoID = Guid.NewGuid();
        }
    }
}
