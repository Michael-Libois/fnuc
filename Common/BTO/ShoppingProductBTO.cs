using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class ShoppingProductBTO
    {

        public int id { get; set; }
        public int productId { get; set; }
        public ProductBTO Product { get; set; }
        public decimal pricePerUnit { get; set; }
        public string name { get; set; }

        public int quantity { get; set; }
        public int ShoppingBasketId { get; set; }
        //public ShoppingBasketBTO ShoppingBasketId { get; set; }


    }
}
