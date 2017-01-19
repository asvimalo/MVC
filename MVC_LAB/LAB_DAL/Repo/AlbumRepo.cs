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
    public class AlbumRepo : IRepo<Album>
    {
        public void Add(Album album)
        {
            using (var context = new GalleryEntities())
            {
                
                context.Albums.Add(album);
                context.SaveChanges();
            }
        }
        //public void AddPhotoToAlbum(Photo photo, Album album)
        //{
        //    using (var context = new GalleryEntities())
        //    {
        //        var albumToAddPhoto = context.Albums.Single(x => x.Id == album.Id);
        //        var photoToAdd = context.Photos.Single(x => x.PhotoID == photo.PhotoID);
        //        albumToAddPhoto.PhotoAlbum.Add(photoToAdd);
                
        //        context.SaveChanges();
        //    }
        //}

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

        public Album Find(Guid ID)
        {
            //Testing eager !!!! Might missing a conf. Tested nedded

            using (var context = new GalleryEntities())
            {
                var albumToFind = context.Albums.Include("User")
                    .Include("Photos")
                    .FirstOrDefault(x => x.Id == ID);
                if (albumToFind !=null)
                {
                    albumToFind.PhotoAlbum = context.Photos.Include("User")
                        .Include("Album")
                        .Include("Comments")
                        .Where(x => x.AlbumID == albumToFind.Id)
                        .ToList();
                }
                return albumToFind;
            }
        }
        //Test after delivered and compare debugging |ref from Book
        public Album Find(Expression<Func<Album, bool>> predicate)
        {
            using (var context = new GalleryEntities())
            {
                return context.Albums.Single(predicate);
            }
        }
        //Wondering if I should create a helper class
        public static IEnumerable<Album> GetAllAlbumsByUserID(Guid userID)
        {
            using (var context = new GalleryEntities())
            {
                return context.Albums.Where(x => x.UserID == userID);
            }
        }
    }
}
