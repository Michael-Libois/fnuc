using Business.Extensions;
using Common.BTO;
using DAL.Context;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ShoppingBasketLogic
    {
        private DatabaseContext context = new DatabaseContext();

        //RetrieveById
        public ShoppingBasketBTO Retrieve(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            return unitOfWork.ShoppingBasketRepo.Retrieve(id).ShoppingBasketToShoppingBasketBTO();
        }


        //RetrieveAll
        public List<ShoppingBasketBTO> RetrieveAll()
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<ShoppingBasketBTO> Listbto = new List<ShoppingBasketBTO>();

            foreach (var item in unitOfWork.ShoppingBasketRepo.RetrieveAll())
            {
                ShoppingBasketBTO btoToAdd = this.Retrieve(item.id);
                Listbto.Add(btoToAdd);
            }
            return Listbto;
        }

        //Create
        public ShoppingBasketBTO Create(ShoppingBasketBTO bto)
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);
            var response = unitOfWork.ShoppingBasketRepo.Create(bto.ShoppingBasketBTOToShoppingBasket());
            unitOfWork.Save();
            return response.ShoppingBasketToShoppingBasketBTO();
        }


        //Delete
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.ShoppingBasketRepo.Delete(id);
            unitOfWork.Save();
        }

        //No Update

    }
}
