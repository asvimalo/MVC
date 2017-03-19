using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_DAL.Models
{
   
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public Album()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
