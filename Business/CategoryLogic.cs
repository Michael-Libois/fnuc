using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.BTO;
using DAL.Context;
using DAL.Repository;
using Business.Extensions;
using DAL.UnitOfWork;

namespace Business
{
    public class CategoryLogic
    {
        private DatabaseContext context = new DatabaseContext();

        //Create 
        public CategoryBTO Create(CategoryBTO bto)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var response = unitOfWork.CategoryRepo.Create(bto.CategoryBTOToCategory());
            unitOfWork.Save();
            return response.CategoryToCategoryBTO();
        }

        public CategoryBTO FillChildrenRec(CategoryBTO CategorieToFindChildren)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var ChildrenOfCategorie =
                unitOfWork.CategoryRepo.RetrieveChildren(CategorieToFindChildren.id)
                    .Select(x => x.CategoryToCategoryBTO()).ToList();


            if (ChildrenOfCategorie.Count()>0)
            {
                CategorieToFindChildren.subCategories = new List<CategoryBTO>();

                foreach (var ChildToFindChildren in ChildrenOfCategorie)
                {
                    CategorieToFindChildren.subCategories.Add(FillChildrenRec(ChildToFindChildren));
                }
            }
            else
                CategorieToFindChildren.subCategories = null;

            return CategorieToFindChildren;
        }

        //Read
        public CategoryBTO Retrieve(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var response = unitOfWork.CategoryRepo.Retrieve(id).CategoryToCategoryBTO();

            response = FillChildrenRec(response);

            return (response == null) ? null : response;
        }

        //ReadAll
        public List<CategoryBTO> RetrieveAllWithChildren()
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            List<CategoryBTO> Listbto = new List<CategoryBTO>();

            foreach (var item in unitOfWork.CategoryRepo.RetrieveAll().Where(x=>x.ParentId==null))
            {
                CategoryBTO btoToAdd = this.Retrieve(item.CategoryId);
                Listbto.Add(btoToAdd);
            }

            return Listbto;
        }

        public List<CategoryBTO> RetrieveAllWithoutChildren()
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<CategoryBTO> Listbto = new List<CategoryBTO>();

            foreach (var item in unitOfWork.CategoryRepo.RetrieveAll())
            {
                CategoryBTO btoToAdd = item.CategoryToCategoryBTO();
                Listbto.Add(btoToAdd);
            }

            return Listbto;

        }
        public List<CategoryBTO> RetrieveAll()
        {

            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<CategoryBTO> Listbto = new List<CategoryBTO>();

            foreach (var item in unitOfWork.CategoryRepo.RetrieveAll())
            {
                CategoryBTO btoToAdd = this.Retrieve(item.CategoryId);
                Listbto.Add(btoToAdd);
            }

            return Listbto;

        }


        //Update
        public void Update(CategoryBTO existingCateg)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.CategoryRepo.Update(existingCateg.CategoryBTOToCategory());
            unitOfWork.Save();
        }



        //Delete
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.CategoryRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}
