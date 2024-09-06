using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ImageId { get; set; }

        public virtual File Image { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new HashSet<CustomerPaymentMethod>();
        public virtual ICollection<CustomerUseCase> UseCases { get; set; } = new HashSet<CustomerUseCase>();
    }
}
