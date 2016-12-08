namespace LAB_DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using LAB_DAL.Models;

    public class GalleryEntities : DbContext
    {
        
        public GalleryEntities()
            : base("name=GalleryEntities")
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Album> Albums { get; set; }
        
    }

    
}