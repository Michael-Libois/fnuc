using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class ShoppingBasketBTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        //public UserBTO User { get; set; }
        public List<ShoppingProductBTO> shoppingProducts { get; set; }
    }
}
