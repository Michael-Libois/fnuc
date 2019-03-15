using Common.BTO;
using DAL.Context;
using DAL.Repository;
using Business.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;

namespace Business
{
    public class ProductLogic
    {

        private DatabaseContext context = new DatabaseContext();

        //Create 
        public ProductBTO Create(ProductBTO bto)
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);
            var response = unitOfWork.ProductRepo.Create(bto.ProductBTOToProduct());
            unitOfWork.Save();
            return response.ProductToProductBTO();


        }

        //Read
        public ProductBTO Retrieve(int id)
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            return unitOfWork.ProductRepo.Retrieve(id).ProductToProductBTO();
            
         
        }

        //ReadAll
        public List<ProductBTO> RetrieveAll()
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<ProductBTO> Listbto = new List<ProductBTO>();

            foreach (var item in unitOfWork.ProductRepo.RetrieveAll())
            {
                ProductBTO btoToAdd = this.Retrieve(item.id);
                Listbto.Add(btoToAdd);
            }

            return Listbto;

        }

        public List<ProductBTO> RetrieveAllByCateg(int id)
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<ProductBTO> Listbto = new List<ProductBTO>();

            foreach (var item in unitOfWork.ProductRepo.RetrieveAll().Where(x=>x.categoryId == id))
            {
                ProductBTO btoToAdd = this.Retrieve(item.id);
                Listbto.Add(btoToAdd);
            }

            return Listbto;

        }

        public List<ProductBTO> RetrieveAllByName(string name)
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<ProductBTO> Listbto = new List<ProductBTO>();

            foreach (var item in unitOfWork.ProductRepo.RetrieveAll().Where(x => x.name == name))
            {
                ProductBTO btoToAdd = this.Retrieve(item.id);
                Listbto.Add(btoToAdd);
            }

            return Listbto;

        }


            //Update

            public void Update(ProductBTO existingCateg)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.ProductRepo.Update(existingCateg.ProductBTOToProduct());
            unitOfWork.Save();
        }



        //Delete
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.ProductRepo.Delete(id);
            unitOfWork.Save();
        }


    }




}
