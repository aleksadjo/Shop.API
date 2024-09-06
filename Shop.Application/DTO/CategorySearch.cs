using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class CategorySearch
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool? WithChildren { get; set; }
    }
}
