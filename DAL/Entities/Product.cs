using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public virtual Category categoryId { get; set; }
        public decimal price { get; set; }
        public DateTime publicationDate { get; set; }

    }
}
