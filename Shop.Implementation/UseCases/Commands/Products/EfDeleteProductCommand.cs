using Shop.Application.UseCases.Commands.Products;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Commands.Products
{
    public class EfDeleteProductCommand : EfDeleteCommand<ImageProduct>, IDeleteProductCommand
    {
        public EfDeleteProductCommand(ShopContext context) : base(context)
        {
        }

        public override int Id => 9;

        public override string Name => "Delete product";
    }
}
