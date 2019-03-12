using Common.BTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class Extensions
    {
        public static Category CategoryBTOToCategory(this CategoryBTO bto)
        {
            return new Category
            {
                ParentId = bto.ParentId,
                Name = bto.Name
            };
        }

        public static CategoryBTO CategoryToCategoryBTO( this Category categ)
        {
            return new CategoryBTO
            {
                ParentId = categ.ParentId,
                Name = categ.Name,
                CategoryId = categ.CategoryId
            };
        }
    }
}
