using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class CustomerUseCase
    {
        public int CustomerId { get; set; }
        public int UseCaseId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
