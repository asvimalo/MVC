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
    public class AlbumRepo
    {
        public void Add(Album album)
        {
            using (var context = new GalleryEntities())
            {
                var newAlbum = new Album
                {
                    Id = Guid.NewGuid(),
                    Name = album.Name,
                    CreatedDate = DateTime.Now,
                    
                    
                };
                context.Albums.Add(newAlbum);
                context.SaveChanges();
            }
        }
        public void AddPhotoToAlbum(Photo photo, Album album)
        {
            using (var context = new GalleryEntities())
            {
                var albumToAddPhoto = context.Albums.Single(x => x.Id == album.Id);
                var photoToAdd = context.Photos.Single(x => x.PhotoID == photo.PhotoID);
                albumToAddPhoto.PhotoAlbum.Add(photoToAdd);
                
                context.SaveChanges();
            }
        }

        public IEnumerable<Album> All()
        {
            using (var context = new GalleryEntities())
            {
                return context.Albums.ToList();

            }
        }

        public void Delete(Guid ID)
        {
            using (var context = new GalleryEntities())
            {
                var AlbumToDelete = context.Albums.Single(x => x.Id == ID);
                context.Albums.Remove(AlbumToDelete);
                context.SaveChanges();
            }
        }

        public Album Find(Expression<Func<Album, bool>> predicate)
        {
            using (var context = new GalleryEntities())
            {
                return context.Albums.Single(predicate);
            }
        }
    }
}
