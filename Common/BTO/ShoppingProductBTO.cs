using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class ShoppingProductBTO
    {

        public int Id { get; set; }
        public ProductBTO ProductId { get; set; }
        public int quantity { get; set; }
        public ShoppingBasketBTO ShoppingBasketId { get; set; }
        

    }
}
