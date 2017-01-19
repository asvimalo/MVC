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
    
    public class CommentRepo : IRepo<Comment>
    {
        public void Add(Comment entity)
        {
            using (var context = new GalleryEntities())
            {
                context.Comments.Add(new Comment
                {
                    ComID = entity.ComID,
                    Comments = entity.Comments,
                    DateCreated = entity.DateCreated,
                    DateChanged = entity.DateChanged,
                    Title = entity.Title,
                    PhotoID = entity.PhotoID,
                    UserID = entity.UserID
                });
                context.SaveChanges();
            }
        }

        public void Add(Comment comment,Photo photo) //Not in use. Replaced by Add(T entity)
        {
            using (var context = new GalleryEntities())
            {
                var newComment = new Comment
                {
                    
                    Comments = comment.Comments,
                    PhotoID = photo.PhotoID,
                };
                context.Comments.Add(newComment);
                context.SaveChanges();
            }
        }

        public IEnumerable<Comment> All()
        {
            using (var context = new GalleryEntities())
            {
                return context.Comments.ToList();

            }
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            using (var context = new GalleryEntities())
            {
                var CommentToDelete = context.Comments.Single(x => x.ComID == ID);
                context.Comments.Remove(CommentToDelete);
                context.SaveChanges();
            }
        }

        public Comment Find(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Comment Find(Expression<Func<Comment, bool>> predicate) // Not in use, but might implement in the future => ex. from book
        {
            using (var context = new GalleryEntities())
            {
                return context.Comments.Single(predicate);
            }
        }
        //Wondering if should add this func to a helper class -TODO 
        public static User GetUserByID(Guid userID)
        {
            using (var context = new GalleryEntities())
            {
                return context.Users.Single(x => x.UserID == userID);
            }
        }
    }
}
