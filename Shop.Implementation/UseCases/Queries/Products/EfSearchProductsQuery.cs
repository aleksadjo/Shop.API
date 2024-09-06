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
    public class EfSearchProductsQuery : EfUseCase, ISearchProductsQuery
    {
        public EfSearchProductsQuery(ShopContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Search Products";

        public PagedResponse<SearchProductResult> Execute(ProductsSearch search)
        {
            var query = Context.ImageProducts.Where(x => x.IsActive)
                                          .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            if (search.Sorts != null && !search.Sorts.Any())
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }
            else
            {
                if (search.Sorts.Any(x => x.SortProperty == "createdAt"))
                {
                    if (search.Sorts.FirstOrDefault(x => x.SortProperty == "createdAt").Direction == SortDirection.Asc)
                    {
                        query = query.OrderBy(x => x.CreatedAt);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.CreatedAt);
                    }
                }
            }

            return Paginate(query, search);
        }

        protected virtual PagedResponse<SearchProductResult> Paginate(IQueryable<ImageProduct> query, PagedSearch search)
        {
            return query.AsPagedReponse(search, x => new SearchProductResult
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                MainImage = x.Images.First().File.Path,
            });
        }
    }

    public class AutomapperSearchProductsQuery : EfSearchProductsQuery
    {
        private readonly IMapper mapper;
        public AutomapperSearchProductsQuery(ShopContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
        protected override PagedResponse<SearchProductResult> Paginate(IQueryable<ImageProduct> query, PagedSearch search)
        {
            return query.AsPagedReponse<ImageProduct, SearchProductResult>(search, mapper);
        }
    }
}
