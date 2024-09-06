using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class ShipmentItem
    {
        public int ShipmentId { get; set; }
        public int OrderItemId { get; set; }

        public virtual Shipment Shipment { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
