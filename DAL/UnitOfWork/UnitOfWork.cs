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
        private ShoppingBasketRepo _shoppingBasketRepo;
        private ShoppingProductRepo _shoppingProductRepo;
        private CategoryRepo _categoryRepo;
        private ProductRepo _productRepo;
        private UserRepo _userRepo;
        private DatabaseContext _datebaseContext;

        public UnitOfWork(DatabaseContext DatabaseContext)
        {

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

        public ShoppingBasketRepo ShoppingBasketRepo
        {
            get
            {
                if (_shoppingBasketRepo == null)
                {
                    _shoppingBasketRepo = new ShoppingBasketRepo(_datebaseContext);
                }
                return _shoppingBasketRepo;
            }

        }


        public ShoppingProductRepo ShoppingProductRepo
        {
            get
            {
                if (_shoppingProductRepo == null)
                {
                    _shoppingProductRepo = new ShoppingProductRepo(_datebaseContext);
                }
                return _shoppingProductRepo;
            }

        }
        public UserRepo UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepo(_datebaseContext);
                }
                return _userRepo;
            }

        }


        public void Save()
        {
            _datebaseContext.SaveChanges();
        }


    }
}
