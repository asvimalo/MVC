using LAB_DAL.EF;
using LAB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAB_DAL.Repo
{
    public class PhotoRepository : IRepo<Photo>
    {
        public void Add(Photo photo)
        {
            using (var context = new GalleryEntities())
            {

                context.Photos.Add(new Photo
                {
                    PhotoID = photo.PhotoID,
                    Path = photo.Path,
                    Name = photo.Name,
                    Description = photo.Description,
                    UploadedDate = photo.UploadedDate,
                    DateChanged = photo.DateChanged,
                    UserID = photo.UserID,
                    AlbumID = photo.AlbumID

                });
                context.SaveChanges();
            }
        }

        public IEnumerable<Photo> All()
        {
            using (var context = new GalleryEntities())
            {
               return context.Photos.ToList();
                
            }
        }

        public void Delete(Guid ID)
        {
            using (var context = new GalleryEntities())
            {
                var PicToDelete = context.Photos.Single(x => x.PhotoID == ID);
                context.Photos.Remove(PicToDelete);
                context.SaveChanges();
            }
        }

        public Photo Find(Guid ID)
        {
            using (var context = new GalleryEntities())
            {
                var PhotoToFind = context.Photos.Include("User").Include("Comments").Include("Album").Single(x => x.PhotoID == ID);
                //Adding Comments whithout lazy Might have a conflict here
                PhotoToFind.Comments = context.Comments.Include("User").Where(x => x.PhotoID == ID).ToList();
                return PhotoToFind;              
            }
        }
        //Still two functions to create
        public Photo MostResentUploadedPicture()
        {
            using (var context = new GalleryEntities())
            {
                var recentUploadedPhoto = context.Photos.Include("User")
                    .Include("Comments")
                    .Include("Album")
                    .OrderByDescending(x => x.UploadedDate)
                    .FirstOrDefault();
                if (recentUploadedPhoto != null)
                {
                    recentUploadedPhoto.Comments = context.Comments.Include("User").Where(x => x.PhotoID == recentUploadedPhoto.PhotoID).ToList();
                }
                return recentUploadedPhoto;
                
            }
        }
        public static User GetUserNameByID(Guid userID)
        {
            using (var context = new GalleryEntities())
            {
                return context.Users.Single(x => x.UserID == userID);
            }
        }
        public static List<Photo> GetLastPicturesUploaded()
        {
            using (var context = new GalleryEntities())
            {
                return context.Photos.OrderByDescending(x => x.UploadedDate).ToList();
            }
        }


    }
}
