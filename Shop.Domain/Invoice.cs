using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Invoice : Entity
    {
        public int OrderId { get; set; }
        public int InvoiceStatusId { get; set; }
        public string Details { get; set; }

        public virtual Order Order { get; set; }
        public virtual InvoiceStatus InvoiceStatus { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; } = new HashSet<Shipment>();
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
