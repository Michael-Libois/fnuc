using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.BTO;
using DAL.Context;
using DAL.Repository;
using Business.Extensions;

namespace Business
{
    public class CategoryLogic
    {
        private DatabaseContext context = new DatabaseContext();

        //Create 
        public CategoryBTO Create(CategoryBTO bto)
        {
            using (CategoryRepo repo = new CategoryRepo(context))
            {
                //De la Logique... 

                repo.Create(bto.CategoryBTOToCategory());
            }

            return bto;
        }

        //Read
        public CategoryBTO Retrieve(int id)
        {
            using (CategoryRepo repo = new CategoryRepo(context))
            {
                //De la Logique... 

                return repo.Retrieve(id).CategoryToCategoryBTO();
            }
        }

        //ReadAll

        //Update

        //Delete

    }
}
