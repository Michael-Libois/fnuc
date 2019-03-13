using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class ProductBTO
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public CategoryBTO category { get; set; }

        public decimal price { get; set; }
        public DateTime publicationDate { get; set; }

    }
}
