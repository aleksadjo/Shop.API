using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class PaymentMethod : Entity
    {
        public string Method { get; set; }
        public virtual ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new HashSet<CustomerPaymentMethod>();
    }
}
