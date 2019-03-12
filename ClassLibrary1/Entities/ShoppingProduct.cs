using System;
using System.Collections.Generic;
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
        public virtual Product productId { get; set; }
        public virtual ShoppingBasket ShoppingBasketId { get; set; }
        public int quantity { get; set; }
    }
}
