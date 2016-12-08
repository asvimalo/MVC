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
    
    public class CommentRepo
    {
        public void Add(Comment comment,Photo photo)
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

        public void Delete(int ID)
        {
            using (var context = new GalleryEntities())
            {
                var CommentToDelete = context.Comments.Single(x => x.ComID == ID);
                context.Comments.Remove(CommentToDelete);
                context.SaveChanges();
            }
        }

        public Comment Find(Expression<Func<Comment, bool>> predicate)
        {
            using (var context = new GalleryEntities())
            {
                return context.Comments.Single(predicate);
            }
        }
    }
}
