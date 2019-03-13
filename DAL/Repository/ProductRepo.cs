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
    public class ProductRepo : Irepository<Product>
    {

        private DatabaseContext dbContext;
        public ProductRepo(DatabaseContext db)
        {
            dbContext = db;
        }


        public Product Create(Product obj)
        {
            //TODO
            obj.category = dbContext.Categories.FirstOrDefault(x=>x.CategoryId == obj.category.CategoryId);

            dbContext.Products.Add(obj);
            //dbContext.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            Product product = Retrieve(id);
            dbContext.Products.Remove(product);
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

        public Product Retrieve(int id)
        {
            return dbContext.Products.FirstOrDefault(u => u.id == id);
        }

        public Product Retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public List<Product> RetrieveAll()
        {
            return dbContext.Products.ToList();
        }

        public void Update(Product obj)
        {
            Product product = Retrieve(obj.id);
            product.name = obj.name;
            product.description = obj.description;
            product.category = obj.category;
            product.price = obj.price;
            product.publicationDate = obj.publicationDate;
            dbContext.SaveChanges();
            
    }
    }
}
