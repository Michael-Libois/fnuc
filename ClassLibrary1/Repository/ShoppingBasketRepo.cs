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
    public class ShoppingBasketRepo : Irepository<ShoppingBasket>
    {

        private DatabaseContext dbContext;
        public ShoppingBasketRepo(DatabaseContext db)
        {
            dbContext = db;
        }


        public ShoppingBasket Create(ShoppingBasket obj)
        {
            dbContext.ShoppingBaskets.Add(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            ShoppingBasket shoppingBasket = Retrieve(id);
            dbContext.ShoppingBaskets.Remove(shoppingBasket);
            dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public ShoppingBasket Retrieve(int id)
        {
            return dbContext.ShoppingBaskets.FirstOrDefault(u => u.id == id);
        }

        public ShoppingBasket Retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingBasket> RetrieveAll()
        {
            return dbContext.ShoppingBaskets.ToList();
        }

        public void Update(ShoppingBasket obj)
        {
            throw new NotImplementedException();
        }
    }
}
