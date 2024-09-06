using Shop.Application.DTO;
using Shop.Application.UseCases.Queries;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Queries
{
    public class EfGetCustomersQuery : EfUseCase, IGetCustomersQuery
    {
        public EfGetCustomersQuery(ShopContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Search Customers";

        public PagedResponse<CustomerDTO> Execute(CustomerSearch search)
        {
            var query = Context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Username.Contains(search.Keyword) ||
                                         x.Email.Contains(search.Keyword));
            }

            if (search.MinOrders.HasValue && search.MinOrders.Value >= 0)
            {
                query = query.Where(x => x.Orders.Count() > search.MinOrders.Value);
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CustomerDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new CustomerDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    ImagePath = x.Image.Path,
                    LastName = x.LastName,
                    Username = x.Username,
                    OrderCount = x.Orders.Count()
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
