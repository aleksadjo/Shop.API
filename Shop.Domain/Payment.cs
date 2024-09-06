using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Payment : Entity
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
