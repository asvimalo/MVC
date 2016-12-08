﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_DAL.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key,Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComID { get; set; }
        
        public string Comments { get; set; }
        [Required]
        public Guid PhotoID { get; set; }
        [ForeignKey("PhotoID")]
        public virtual Photo Photo { get; set; }
    }
}