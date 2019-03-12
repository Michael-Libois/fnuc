using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShoppingBasket
    {

        public int id { get; set; }
        public User userId { get; set; }
        public virtual ICollection<ShoppingProduct> ShoppingProducts { get; set; }

        //     id: number;
        //userId: number;
        //shoppingProducts: Array<ShoppingProduct>;

    }
}
