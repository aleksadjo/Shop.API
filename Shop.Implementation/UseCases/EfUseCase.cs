using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly ShopContext _context;

        protected EfUseCase(ShopContext context)
        {
            _context = context;
        }

        protected ShopContext Context => _context;
    }
}
