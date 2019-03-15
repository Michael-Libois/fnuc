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
                CategoryId = bto.id,
                Name = bto.name,
                ParentId = bto.ParentId
            };
        }

        public static CategoryBTO CategoryToCategoryBTO(this Category categ)
        {
            return new CategoryBTO
            {
                name = categ.Name,
                ParentId = categ.ParentId,
                id = categ.CategoryId
            };
        }


        public static Product ProductBTOToProduct(this ProductBTO bto)
        {
            //return new Product
            //{
            //    name = bto.name,
            //    description = bto.description,
            //    price = bto.price,
            //    publicationDate = bto.publicationDate,
            //    categoryId = (Category)bto.categoryId
            //   //public int id { get; set; }

            //};
            bto.publicationDate = DateTime.Now;
            Product product = new Product();
            product.name = bto.name;
            product.description = bto.description;
            product.price = bto.price;
            product.publicationDate = bto.publicationDate;
            product.categoryId = bto.categoryId;
            //product.category = bto.category.CategoryBTOToCategory();


            return product;
            //public int id { get; set; }
        }

        public static ProductBTO ProductToProductBTO(this Product produc)
        {
            if (produc == null) return new ProductBTO();

                return new ProductBTO
                {
                    //Parent = categ.Parent,
                    name = produc.name,
                    id = produc.id,
                    description = produc.description,
                    price = produc.price,
                    publicationDate = produc.publicationDate,
                    categoryId = produc.categoryId,
                    category = produc.category.Name
                    //category = produc.category.CategoryToCategoryBTO()
                };

        }

        public static User UserBTOToUser(this UserBTO bto)
        {
            return new User
            {
                Id = bto.Id,
                Name = bto.Name
            };
        }

        public static UserBTO UserToUserBTO(this User user)
        {
            return new UserBTO
            {
                Name = user.Name,
                Id = user.Id
            };
        }

        public static ShoppingBasket ShoppingBasketBTOToShoppingBasket(this ShoppingBasketBTO bto)
        {
            return new ShoppingBasket
            {
                id = bto.id,
                userId = bto.userId
                //userId = bto.UserId.UserBTOToUser()
            };
        }

        public static ShoppingBasketBTO ShoppingBasketToShoppingBasketBTO(this ShoppingBasket basket)
        {
            return new ShoppingBasketBTO
            {
                userId = basket.userId,
                id = basket.id,
                shoppingProducts = basket.ShoppingProducts?.Select(x => x.ShoppingProductToShoppingProductBTO()).ToList()
            };
        }

        public static ShoppingProduct ShoppingProductBTOToShoppingProduct(this ShoppingProductBTO bto)
        {
            return new ShoppingProduct
            {
                id = bto.id,
                productId = bto.productId,
                quantity = bto.quantity,
                //product = bto.Product.ProductBTOToProduct(),
                shoppingBasketId = bto.ShoppingBasketId
                //ShoppingBasketId = bto.ShoppingBasketId.ShoppingBasketBTOToShoppingBasket()
            };

        

        }
        public static ShoppingProductBTO ShoppingProductToShoppingProductBTO(this ShoppingProduct shoppingProduct)
        {
            return new ShoppingProductBTO
            {

                id = shoppingProduct.id,
                productId = shoppingProduct.productId,
                quantity = shoppingProduct.quantity,
                ShoppingBasketId = shoppingProduct.shoppingBasketId,
                pricePerUnit = shoppingProduct.product.price,
                name = shoppingProduct.product.name

            };
        }
    }
}
