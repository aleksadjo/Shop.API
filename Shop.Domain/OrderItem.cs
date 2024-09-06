using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class OrderItem : Entity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int OrderItemStatusId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderItemStatus OrderItemStatus { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new HashSet<ShipmentItem>();
    }
}
