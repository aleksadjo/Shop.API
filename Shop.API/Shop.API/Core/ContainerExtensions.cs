using Shop.API.Validation;
using Shop.Application.UseCases.Commands.Categories;
using Shop.Application;
using Shop.Implementation.Logging.UseCases;
using Shop.Implementation.UseCases.Commands.Categories;
using Shop.Implementation;
using System.IdentityModel.Tokens.Jwt;
using Shop.Implementation.Validators;
using Shop.Application.UseCases.Commands.Customers;
using Shop.Implementation.UseCases.Commands.Customers;
using Shop.Application.UseCases.Queries;
using Shop.Implementation.UseCases.Queries;
using Shop.Implementation.UseCases.Queries.Products;
using Shop.Implementation.UseCases.Commands.Products;
using Shop.Application.UseCases.Commands.Products;
using Shop.Application.UseCases.Queries.Products;

namespace Shop.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<CreateCategoryDTOValidator>();
            services.AddTransient<UpdateCustomerAccessDTOValidator>();
            services.AddTransient<CreateImageProductDTOValidator>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IUpdateCustomerAccessCommand, EfUpdateCustomerAccessCommand>();
            services.AddTransient<ICreateImageProductCommand, EfCreateImageProductCommand>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IRegisterCustomerCommand, EfRegisterCustomerCommand>();
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
            services.AddTransient<RegisterCustomerDTOValidator>();
            services.AddTransient<IGetCustomersQuery, EfGetCustomersQuery>();
            services.AddTransient<ISearchProductsQuery, AutomapperSearchProductsQuery>();
            services.AddTransient<IGetProductQuery, EfGetProductQuery>();
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
