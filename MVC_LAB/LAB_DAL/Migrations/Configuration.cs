namespace LAB_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LAB_DAL.EF;
    using LAB_DAL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LAB_DAL.EF.GalleryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LAB_DAL.EF.GalleryEntities context)
        {

            context.Photos.AddOrUpdate(x => x.Id,

              new Photo {
                  Id = Guid.Parse("69093d3a-0375-41d6-949e-bf4b043aafd8"),
                  FileName = "art_4.jpg",
                  Name = "Manos Unidas",
                  Description = "A touch of peace",
                  DateAdded = DateTime.Now.AddHours(-5),
                  AlbumId = Guid.Parse("d59ed275-f763-4b56-8427-64591fb928c1"),
                  UserId = Guid.Parse("f324e4d5-2dfb-487a-bc1e-e95a69310e66")
              },
              new Photo {
                  Id = Guid.Parse("a70e1ca6-cc95-4751-a21f-ac306af40e4e"),
                  FileName = "artistic-images-1.jpg", Name = "Lapices de colores",
                  Description = "Inspiration",
                  DateAdded = DateTime.Now,
                  AlbumId = Guid.Parse("d59ed275-f763-4b56-8427-64591fb928c1"),
                  UserId = Guid.Parse("469ebc0f-1a9c-4ff9-91d2-ed36ce16d8db")
              },
              new Photo {
                  Id = Guid.Parse("125d7a9a-59e0-4087-af0d-0eccea1fb289"),
                  FileName = "artistic-lips_2.jpg",
                  Name = "Pasion",
                  Description = "A Kiss",
                  DateAdded = DateTime.Now.AddDays(-15),
                  AlbumId = Guid.Parse("d59ed275-f763-4b56-8427-64591fb928c1"),
                  UserId = Guid.Parse("fa014d12-bfaa-487c-9a66-fb7750bd4ece")
              },
              new Photo {
                  Id = Guid.Parse("94f2370d-5035-4f56-9530-ce1fca50677f"),
                  FileName = "Holi_colours_3.jpg",
                  Name = "Mercado de las especias",
                  Description = "Old Market",
                  DateAdded = DateTime.Now.AddDays(-12),
                  AlbumId = Guid.Parse("d59ed275-f763-4b56-8427-64591fb928c1"),
                  UserId = Guid.Parse("cab2f1f2-d07d-43fe-8286-54db4f2a69bc")
              }

            );
            context.Users.AddOrUpdate(x => x.Id,

             new User { Id = Guid.Parse("f324e4d5-2dfb-487a-bc1e-e95a69310e66"), Name = "Ulf Littorin", Email = "littorin@gmail.com", Password = "elcubano", Admin = false },
             new User { Id = Guid.Parse("469ebc0f-1a9c-4ff9-91d2-ed36ce16d8db"), Name = "Andrés ElMago", Email = "andres@gmail.com", Password = "elriojano", Admin = true },
             new User { Id = Guid.Parse("fa014d12-bfaa-487c-9a66-fb7750bd4ece"), Name = "Filip Kacl", Email = "kacl@gmail.com", Password = "elserbio", Admin = false },
             new User { Id = Guid.Parse("cab2f1f2-d07d-43fe-8286-54db4f2a69bc"), Name = "Max Frediani", Email = "frediani@gmail.com", Password = "ellisto", Admin = false }

           );
            context.Albums.AddOrUpdate(x => x.Id,

             new Album { Id = Guid.Parse("d59ed275-f763-4b56-8427-64591fb928c1"), Name = "elcubano", UserId = Guid.Parse("f324e4d5-2dfb-487a-bc1e-e95a69310e66") }

           );
            context.Comments.AddOrUpdate(x => x.Id,
            new Comment
            {
                Id = Guid.NewGuid(),
                Text = "A travel around the world",
                PhotoId = Guid.Parse("125d7a9a-59e0-4087-af0d-0eccea1fb289"),
                Date = DateTime.Now.AddDays(-15),
                UserId = Guid.Parse("f324e4d5-2dfb-487a-bc1e-e95a69310e66")
            },
            new Comment
            {
                Id = Guid.NewGuid(),
                Text = "Woow amazing...",
                PhotoId = Guid.Parse("94f2370d-5035-4f56-9530-ce1fca50677f"),
                Date = DateTime.Now.AddYears(-1),
                UserId = Guid.Parse("cab2f1f2-d07d-43fe-8286-54db4f2a69bc")
            },
            new Comment
            {
                Id = Guid.NewGuid(),
                Text = "Fantastik...",
                PhotoId = Guid.Parse("69093d3a-0375-41d6-949e-bf4b043aafd8"),
                Date = DateTime.Now.AddYears(-1),
                UserId = Guid.Parse("469ebc0f-1a9c-4ff9-91d2-ed36ce16d8db")
            },
            new Comment
            {
                Id = Guid.NewGuid(),
                Text = "Crazy...",
                PhotoId = Guid.Parse("a70e1ca6-cc95-4751-a21f-ac306af40e4e"),
                Date = DateTime.Now.AddYears(-1),
                UserId = Guid.Parse("fa014d12-bfaa-487c-9a66-fb7750bd4ece")
            });
        }
    }
}

