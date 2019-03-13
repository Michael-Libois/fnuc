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
            using (CategoryRepo repo = new CategoryRepo(context))
            {
                //De la Logique... 

                repo.Create(bto.CategoryBTOToCategory());
            }

            return bto;
        }

        public CategoryBTO FillChildrenRec(CategoryBTO CategorieToFindChildren)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var ChildrenOfCategorie =
                unitOfWork.CategoryRepo.RetrieveChildren(CategorieToFindChildren.Id)
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

            //using (CategoryRepo repo = new CategoryRepo(context))
            //{
            //    var obj = repo.Retrieve(id);


            //    var Response = obj.CategoryToCategoryBTO();
            //    Response.subCategories = repo.RetrieveChildren(id)
            //        .Select(x => x.CategoryToCategoryBTO()).ToList();

            //    return Response;
            //}
        }

        //ReadAll

        //Update

        //Delete

    }
}
