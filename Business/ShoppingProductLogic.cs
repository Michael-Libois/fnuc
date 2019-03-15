using Business.Extensions;
using Common.BTO;
using DAL.Context;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ShoppingProductLogic
    {
        private DatabaseContext context = new DatabaseContext();

        //RetrieveById
        public ShoppingProductBTO Retrieve(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            return unitOfWork.ShoppingProductRepo.Retrieve(id).ShoppingProductToShoppingProductBTO();
        }





        //RetrieveAll
        public List<ShoppingProductBTO> RetrieveAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<ShoppingProductBTO> Listbto = new List<ShoppingProductBTO>();

            foreach (var item in unitOfWork.ShoppingProductRepo.RetrieveAll())
            {
                ShoppingProductBTO btoToAdd = this.Retrieve(item.id);
                Listbto.Add(btoToAdd);
            }
            return Listbto;
        }

        //RetrieveShoppingProductByBasketId
        public List<ShoppingProductBTO> RetrieveAllByShoppinBasketId(int basketId)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<ShoppingProductBTO> Listbto = new List<ShoppingProductBTO>();

            foreach (var item in unitOfWork.ShoppingProductRepo.RetrieveAll().Where(x => x.shoppingBasketId == basketId))
            {
                ShoppingProductBTO btoToAdd = this.Retrieve(item.id);
                Listbto.Add(btoToAdd);
            }
            return Listbto;
        }



        //Create
        public ShoppingProductBTO Create(ShoppingProductBTO bto)
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);
            var response = unitOfWork.ShoppingProductRepo.Create(bto.ShoppingProductBTOToShoppingProduct());
            unitOfWork.Save();
            return response.ShoppingProductToShoppingProductBTO();
        }

        //Update
        public void Update(ShoppingProductBTO existingShoppingProductBTO)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.ShoppingProductRepo.Update(existingShoppingProductBTO.ShoppingProductBTOToShoppingProduct());
            unitOfWork.Save();
        }

        //Delete
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.ShoppingProductRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}
