using Common.BTO;
using DAL.Context;
using DAL.Repository;
using Business.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class ProductLogic
    {

        private DatabaseContext context = new DatabaseContext();

        //Create 
        public ProductBTO Create(ProductBTO bto)
        {
            using (ProductRepo repo = new ProductRepo(context))
            {
                //De la Logique... 

                repo.Create(bto.ProductBTOToProduct());
            }

            return bto;
        }

        //Read
        public ProductBTO Retrieve(int id)
        {
            using (ProductRepo repo = new ProductRepo(context))
            {
                //De la Logique... 

                return repo.Retrieve(id).ProductToProductBTO();
            }
        }

        //ReadAll
        public List<ProductBTO> RetrieveAll()
        {
            using (ProductRepo repo = new ProductRepo(context))
            {
                //De la Logique... 
                return RetrieveAll();
                
            }
        }
        //Update

        //Delete

    }




}
