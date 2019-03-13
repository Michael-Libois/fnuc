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
    public class UserLogic
    {
        private DatabaseContext context = new DatabaseContext();

        //Create
        public UserBTO Create(UserBTO bto)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var response = unitOfWork.UserRepo.Create(bto.UserBTOToUser());
            unitOfWork.Save();
            return response.UserToUserBTO();
        }

        //Read
        public UserBTO Retrieve(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var response = unitOfWork.UserRepo.Retrieve(id).UserToUserBTO();

            //response = FillChildrenRec(response);

            return (response == null) ? null : response;
        }

        //ReadAll
        public List<UserBTO> RetrieveAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            List<UserBTO> Listbto = new List<UserBTO>();

            foreach (var item in unitOfWork.UserRepo.RetrieveAll())
            {
                UserBTO btoToAdd = this.Retrieve(item.Id);
                Listbto.Add(btoToAdd);
            }

            return Listbto;
        }
        //Update
        public void Update(UserBTO existingCateg)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.UserRepo.Update(existingCateg.UserBTOToUser());
            unitOfWork.Save();
        }

        //Delete
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.UserRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}
