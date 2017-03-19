using LAB_DAL.EF;
using LAB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_DAL.Repo
{
    public class UserRepo : IRepository<User>
    {
        public void Add(User item)
        {
            using (var db = new GalleryEntities())
            {
                db.Users.Add(new User
                {
                    Id = item.Id,
                    Email = item.Email,
                    Name = item.Name,
                    Password = item.Password,
                    Admin = false
                });

                db.SaveChanges();
            }
        }

        public void Edit(User item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetItems()
        {
            throw new NotImplementedException();
        }

        public User FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByCredentials(string email, string password)
        {
            using (var db = new GalleryEntities())
            {
                return db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            }
        }

        public static Guid GetUserId(string name)
        {
            using (var db = new GalleryEntities())
            {
                return db.Users.Single(x => x.Name == name).Id;
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
