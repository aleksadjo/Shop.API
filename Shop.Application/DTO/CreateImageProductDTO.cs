using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class CreateImageProductDTO
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
