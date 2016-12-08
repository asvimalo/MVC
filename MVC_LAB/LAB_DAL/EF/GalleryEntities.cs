namespace LAB_DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using LAB_DAL.Models;

    public class GalleryEntities : DbContext
    {
        // Your context has been configured to use a 'GalleryEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LAB_DAL.EF.GalleryEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GalleryEntities' 
        // connection string in the application configuration file.
        public GalleryEntities()
            : base("name=GalleryEntities")
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Album> Ambums { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}