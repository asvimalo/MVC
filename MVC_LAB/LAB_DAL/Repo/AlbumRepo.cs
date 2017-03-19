using LAB_DAL.EF;
using LAB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAB_DAL.Repo
{
    public class AlbumRepo : IRepository<Album>
    {
        public void Add(Album item)
        {
            using (var db = new GalleryEntities())
            {
                db.Albums.Add(item);

                db.SaveChanges();
            }
        }

        public void Edit(Album photo)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetItems()
        {
            using (var db = new GalleryEntities())
            {
                return db.Albums.Include("User").Include("Photos").ToList();
            }
        }

        public Album FindById(Guid id)
        {
            using (var db = new GalleryEntities())
            {
                var album = db.Albums.Include("User").Include("Photos").FirstOrDefault(x => x.Id == id);
                if (album != null)
                {
                    album.Photos =
                        db.Photos.Include("User")
                            .Include("Album")
                            .Include("Comments")
                            .Where(x => x.AlbumId == album.Id)
                            .ToList();
                }
                return album;
            }
        }

        public static List<Album> GetAlbumsByUserId(Guid id)
        {
            using (var db = new GalleryEntities())
            {
                return db.Albums.Where(x => x.UserId == id).ToList();
            }
        }
    }
}
