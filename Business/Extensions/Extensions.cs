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
                Name = bto.Name
            };
        }

        public static CategoryBTO CategoryToCategoryBTO( this Category categ)
        {
            return new CategoryBTO
            {
                Name = categ.Name,
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
                publicationDate = bto.publicationDate
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
                publicationDate = produc.publicationDate
            };
        }

    }
}
