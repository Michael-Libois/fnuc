using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork
    {
        private CategoryRepo _categoryRepo;
        private ProductRepo _productRepo;
        private DatabaseContext _datebaseContext;

        public UnitOfWork(DatabaseContext DatabaseContext) {

            _datebaseContext = DatabaseContext;


        }

    public CategoryRepo CategoryRepo
        {
            get
            {
                if(_categoryRepo == null)
                {
                    _categoryRepo = new CategoryRepo(_datebaseContext);
                }
                return _categoryRepo;
            }

        }

        public ProductRepo ProductRepo
        {
            get
                {
                if (_productRepo == null)
                {
                    _productRepo = new ProductRepo(_datebaseContext);
                }
                return _productRepo;
            }

        }


        public void Save()
        {
            _datebaseContext.SaveChanges();
        }


    }
}
