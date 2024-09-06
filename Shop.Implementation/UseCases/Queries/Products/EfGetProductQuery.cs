using AutoMapper;
using Shop.Application.DTO;
using Shop.Application.UseCases.Queries.Products;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Queries.Products
{
    public class EfGetProductQuery : EfFindUseCase<ProductDTO, ImageProduct>, IGetProductQuery
    {
        public EfGetProductQuery(ShopContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override int Id => 8;

        public override string Name => "Find Product";
    }
}
