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

        public List<CategoryBTO> Children { get; set; }
    }
}
