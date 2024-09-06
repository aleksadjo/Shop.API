using FluentValidation;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Customers;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Commands.Customers
{
    public class EfRegisterCustomerCommand : EfUseCase, IRegisterCustomerCommand
    {
        public int Id => 2;

        public string Name => "CustomerRegistration";

        private ShopContext Context;
        private RegisterCustomerDTOValidator _validator;

        public EfRegisterCustomerCommand(ShopContext context, RegisterCustomerDTOValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public void Execute(RegisterCustomerDTO data)
        {
            _validator.ValidateAndThrow(data);

            Customer customer = new Customer
            {
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Password = data.Password,
                Image = Context.Files.FirstOrDefault(x => x.Path.Contains("default")),
                Username = data.Username
            };

            Context.Customers.Add(customer);

            Context.SaveChanges();
        }
    }
}
