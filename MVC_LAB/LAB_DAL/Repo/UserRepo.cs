using LAB_DAL.EF;
using LAB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_DAL.Repo
{
    public class UserRepo : IRepo<User>
    {
        public void Add(User entity)
        {
            using (var context = new GalleryEntities())
            {
                context.Users.Add(new Models.User
                {
                    UserID = entity.UserID,
                    Email = entity.Email,
                    Name = entity.Password,
                    isAdmin = false 
                });
                context.SaveChanges();
            }
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public User Find(Guid ID)
        {
            throw new NotImplementedException();
        }
        public User GetUserAuth(string email, string password)
        {
            using (var context = new GalleryEntities())
            {
                return context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            }
        }

        //if changed to helper might change context (a thought) Not tested
        public static Guid getUserID(string name)
        {
            using (var context = new GalleryEntities())
            {
                return context.Users.Single(x => x.Name == name).UserID;
            }
        }
        public static string getUserName(Guid userID)
        {
            using (var context = new GalleryEntities())
            {
                return context.Users.Single(x => x.UserID == userID).Name;
            }
        }
    }
}
