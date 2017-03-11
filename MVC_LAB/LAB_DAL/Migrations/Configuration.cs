namespace LAB_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EF;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LAB_DAL.EF.GalleryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GalleryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Photos.AddOrUpdate(x => x.PhotoID,

              new Photo { PhotoID = Guid.Parse("69093d3a-0375-41d6-949e-bf4b043aafd8") , Path = "~/Images/art_4.jpg",  Name = "Manos Unidas", UploadedDate = DateTime.Now, UserID = Guid.Parse("f324e4d5-2dfb-487a-bc1e-e95a69310e66") },
              new Photo { PhotoID = Guid.Parse("a70e1ca6-cc95-4751-a21f-ac306af40e4e"), Path = "~/Images/artistic-images-1.jpg", Name = "Lapices de colores", UploadedDate = DateTime.Now, UserID = Guid.Parse("469ebc0f-1a9c-4ff9-91d2-ed36ce16d8db") },
              new Photo { PhotoID = Guid.Parse("125d7a9a-59e0-4087-af0d-0eccea1fb289"), Path = "~/Images/artistic-lips_2.jpg", Name = "Pasion", UploadedDate = DateTime.Now, UserID = Guid.Parse("fa014d12-bfaa-487c-9a66-fb7750bd4ece") },
              new Photo { PhotoID = Guid.Parse("94f2370d-5035-4f56-9530-ce1fca50677f"), Path = "~/Images/Holi_colours_3.jpg", Name = "Mercado de las especias", UploadedDate = DateTime.Now, UserID = Guid.Parse("cab2f1f2-d07d-43fe-8286-54db4f2a69bc") }

            );
            context.Users.AddOrUpdate(x => x.UserID, 

             new User { UserID = Guid.Parse("f324e4d5-2dfb-487a-bc1e-e95a69310e66"),  Name = "Ulf Littorin" , Email = "littorin@gmail.com", Password = "elcubano", isAdmin = false},
             new User { UserID = Guid.Parse("469ebc0f-1a9c-4ff9-91d2-ed36ce16d8db"), Name = "Andrés ElMago", Email = "andres@gmail.com", Password = "elriojano", isAdmin = true },
             new User { UserID = Guid.Parse("fa014d12-bfaa-487c-9a66-fb7750bd4ece"), Name = "Filip Kacl", Email = "kacl@gmail.com", Password = "elserbio", isAdmin = false },
             new User { UserID = Guid.Parse("cab2f1f2-d07d-43fe-8286-54db4f2a69bc"), Name = "Max Frediani", Email = "frediani@gmail.com", Password = "ellisto", isAdmin = false }

           );
            //
        }
    }
}
