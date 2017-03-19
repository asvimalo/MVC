using LAB_DAL.EF;
using LAB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LAB_DAL.Repo
{
    public class PhotoRepository : IRepository<Photo>
    {
        public void Add(Photo item)
        {
            using (var db = new GalleryEntities())
            {
                db.Photos.Add(item);

                db.SaveChanges();
            }
        }

        public void Edit(Photo item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetItems()
        {
            using (var db = new GalleryEntities())
            {
                return db.Photos.Include("Comments").Include("Album").Include("User").ToList();
            }
        }

        public Photo FindById(Guid id)
        {
            using (var db = new GalleryEntities())
            {
                var photo = db.Photos.Include("User").Include("Comments").Include("Album").FirstOrDefault(x => x.Id == id);
                photo.Comments = db.Comments.Include("User").Where(x => x.PhotoId == photo.Id).ToList();

                return photo;
            }
        }

        public Photo GetLastUploadedPhoto()
        {
            using (var db = new GalleryEntities())
            {
                var photo =
                    db.Photos.Include("User")
                        .Include("Comments")
                        .Include("Album")
                        .OrderByDescending(x => x.DateAdded)
                        .FirstOrDefault();
                if (photo != null)
                    photo.Comments = db.Comments.Include("User").Where(x => x.PhotoId == photo.Id).ToList();

                return photo;
            }
        }

        public static string GetUserName(Guid id)
        {
            using (var db = new GalleryEntities())
            {
                return db.Users.Single(x => x.Id == id).Name;
            }
        }

    }
}
