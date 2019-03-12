using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class CategoryBTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //public int? ParentId { get; set; }
        //public virtual Category Parent { get; set; }

        //public virtual List<Category> Children { get; set; }
        //public virtual List<Product> Products { get; set; }
    }
}
