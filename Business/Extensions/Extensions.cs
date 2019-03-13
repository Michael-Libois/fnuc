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
                CategoryId = bto.Id,
                Name = bto.Name,
                ParentId = bto.ParentId
            };
        }

        public static CategoryBTO CategoryToCategoryBTO( this Category categ)
        {
            return new CategoryBTO
            {
                Name = categ.Name,
                ParentId = categ.ParentId,
                Id = categ.CategoryId
            };
        }


        public static Product ProductBTOToProduct(this ProductBTO bto)
        {
            return new Product
            {
                name = bto.name,
                description = bto.description,
                price = bto.price,
                publicationDate = bto.publicationDate,
                categoryId = (Category)bto.categoryId
               //public int id { get; set; }
        
            };
        }

        public static ProductBTO ProductToProductBTO(this Product produc)
        {
            return new ProductBTO
            {
                //Parent = categ.Parent,
                name = produc.name,
                id = produc.id,
                description = produc.description,
                price = produc.price,
                publicationDate = produc.publicationDate,
                categoryId = produc.categoryId
            };
        }

    }
}
