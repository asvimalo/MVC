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
    public class PhotoRepository 
    {
        public void Add(Photo photo)
        {
            using (var context = new GalleryEntities())
            {
                
                context.Photos.Add(photo);
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

        public Photo Find(Expression<Func<Photo, bool>> predicate)
        {
            using (var context = new GalleryEntities())
            {
                return context.Photos.Single(predicate);               
            }
        }
    }
}
