using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShoppingBasket
    {

        public int id { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }
        public virtual ICollection<ShoppingProduct> ShoppingProducts { get; set; }

        //     id: number;
        //userId: number;
        //shoppingProducts: Array<ShoppingProduct>;

    }
}
