using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Shipment : Entity
    {
        public int OrderId { get; set; }
        public int InvoiceId { get; set; }
        public string TrackingNumber { get; set; }
        public string Details { get; set; }

        public virtual Order Order { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new HashSet<ShipmentItem>();
    }
}
