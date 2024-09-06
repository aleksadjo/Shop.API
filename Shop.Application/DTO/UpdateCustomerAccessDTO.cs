using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class UpdateCustomerAccessDTO
    {
        public int CustomerId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
