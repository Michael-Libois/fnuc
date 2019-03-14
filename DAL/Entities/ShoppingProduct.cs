using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShoppingProduct
    {
        //public ShoppingProduct()
        //{
        //    this. = new HashSet<Course>();
        //}
        
        public int id { get; set; }
        public int quantity { get; set; }
        public virtual Product product { get; set; }
        public virtual ShoppingBasket shoppingBasket { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }

        [ForeignKey("shoppingBasket")]
        public int shoppingBasketId { get; set; }
    }
}
