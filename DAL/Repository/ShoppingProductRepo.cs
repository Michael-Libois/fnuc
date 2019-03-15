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
    public class ShoppingProductRepo : Irepository<ShoppingProduct>
    {

        private DatabaseContext dbContext;
        public ShoppingProductRepo(DatabaseContext db)
        {
            dbContext = db;
        }


        public ShoppingProduct Create(ShoppingProduct obj)
        {
            dbContext.ShoppingProducts.Add(obj);
            //dbContext.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            ShoppingProduct shoppingProduct = Retrieve(id);
            dbContext.ShoppingProducts.Remove(shoppingProduct);
            //dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public ShoppingProduct Retrieve(int id)
        {
            return dbContext.ShoppingProducts.FirstOrDefault(u => u.id == id);
        }

        public ShoppingProduct Retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingProduct> RetrieveAll()
        {
            return dbContext.ShoppingProducts.ToList();
        }



        public void Update(ShoppingProduct obj)
        {
            ShoppingProduct shoppingProduct = Retrieve(obj.id);
            shoppingProduct.quantity = obj.quantity;
            shoppingProduct.productId = obj.productId;
            //shoppingProduct.ShoppingBasketId = obj.ShoppingBasketId;
            //dbContext.SaveChanges();

        }
    }
}
