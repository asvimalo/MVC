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
    
    public class CommentRepo : IRepository<Comment>
    {
        public void Add(Comment item)
        {
            using (var db = new GalleryEntities())
            {
                db.Comments.Add(new Comment
                {
                    Id = item.Id,
                    Text = item.Text,
                    Date = item.Date,
                    PhotoId = item.PhotoId,
                    UserId = item.UserId
                });

                db.SaveChanges();
            }
        }

        public void Edit(Comment item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetItems()
        {
            throw new NotImplementedException();
        }

        public Comment FindById(Guid id)
        {
            throw new NotImplementedException();
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
