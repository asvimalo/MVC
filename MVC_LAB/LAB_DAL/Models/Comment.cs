 using System;
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
        public string Title { get; set; }
        public string Comments { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<DateTime> DateChanged { get; set; }

        public Guid? PhotoID { get; set; }
        public Guid UserID { get; set; }

        [ForeignKey("PhotoID")]
        public virtual Photo Photo { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
