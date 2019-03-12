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
    public class CategoryRepo : Irepository<Category>
    {

        private DatabaseContext dbContext;
        public CategoryRepo(DatabaseContext db)
        {
            dbContext = db;
        }


        public Category Create(Category obj)
        {
            dbContext.Categories.Add(obj);
            dbContext.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            Category category = Retrieve(id);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Category category = Retrieve(id);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Category Retrieve(int id)
        {
            return dbContext.Categories.FirstOrDefault(u => u.CategoryId == id);
        }

        public Category Retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public List<Category> RetrieveAll()
        {
            return dbContext.Categories.ToList();
        }

        public void Update(Category obj)
        {
            
            Category category = Retrieve(obj.CategoryId);
            category.Name = obj.Name;
            category.ParentId = obj.ParentId;
            dbContext.SaveChanges();


            
        }
    }
}
