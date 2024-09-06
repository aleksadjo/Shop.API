using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class CustomerSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public int? MinOrders { get; set; }
    }
}
