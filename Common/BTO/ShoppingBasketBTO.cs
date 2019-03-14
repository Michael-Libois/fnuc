using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class ShoppingBasketBTO
    {
        public int Id { get; set; }
        public UserBTO UserId { get; set; }
        //public List<ShoppingProductBTO> shoppingProductBTOs { get; set; }
    }
}
