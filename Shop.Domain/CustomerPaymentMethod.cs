using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class CustomerPaymentMethod : Entity
    {
        public int CustomerId { get; set; }
        public int PaymentMethodId { get; set; }
        public string CardNumber { get; set; }
        public string Details { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
