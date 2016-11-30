using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kunskapkoll.Models
{
    public class Person
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime UpdateAddress { get; set; }

    }
}