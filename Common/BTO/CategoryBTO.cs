using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class CategoryBTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryBTO> subCategories { get; set; }
    }
}
