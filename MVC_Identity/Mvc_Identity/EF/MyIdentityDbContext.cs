using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mvc_Identity.EF
{
    public class MyIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MyIdentityDbContext() : base("MvcTest")
        {

        }
    }
}