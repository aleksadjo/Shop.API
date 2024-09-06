using Microsoft.EntityFrameworkCore;
using Shop.Application;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation
{
    public class BasicAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;
        private ShopContext _context;

        public BasicAuthorizationApplicationActorProvider(string authorizationHeader, ShopContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }

        public IApplicationActor GetActor()
        {
            if (_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
            {
                return new UnauthorizedActor();
            }

            var base64Data = _authorizationHeader.Split(" ")[1];

            var bytes = Convert.FromBase64String(base64Data);

            var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

            if (decodedCredentials.Split(":").Length < 2)
            {
                throw new InvalidOperationException("Invalid Basic authorization header.");
            }

            string username = decodedCredentials.Split(":")[0];
            string password = decodedCredentials.Split(":")[1];

            Customer c = _context.Customers.Include(x => x.UseCases)
                                   .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (c == null)
            {
                return new UnauthorizedActor();
            }

            var useCases = c.UseCases.Select(x => x.UseCaseId).ToList();

            return new Actor
            {
                Email = c.Email,
                FirstName = c.FirstName,
                Id = c.Id,
                LastName = c.LastName,
                Username = c.Username,
                AllowedUseCases = useCases
            };
        }
    }
}
