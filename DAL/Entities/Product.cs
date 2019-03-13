using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("category")]
        public int categoryId { get; set; }
        public virtual Category category { get; set; }

        public decimal price { get; set; }
        public DateTime publicationDate { get; set; }

    }
}
