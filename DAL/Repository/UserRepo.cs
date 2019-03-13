using Common.interfaces;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepo : Irepository<User>
    {
        private DatabaseContext dbContext;
        public UserRepo(DatabaseContext db)
        {
            dbContext = db;
        }

        public User Create(User obj)
        {
            dbContext.Users.Add(obj);
            return obj;
        }

        public void Delete(int id)
        {
            User user = Retrieve(id);
            dbContext.Users.Remove(user);
        }

        public void Delete(string id)
        {
            User user = Retrieve(id);
            dbContext.Users.Remove(user);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public User Retrieve(int id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> RetrieveAll()
        {
            return dbContext.Users.ToList();
        }

        public void Update(User obj)
        {
            User user = Retrieve(obj.Id);
            user.Name = obj.Name;
        }
    }
}
