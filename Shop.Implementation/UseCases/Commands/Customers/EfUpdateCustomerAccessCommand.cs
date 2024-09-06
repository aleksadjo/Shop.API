using FluentValidation;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Customers;
using Shop.DataAccess;
using Shop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Commands.Customers
{
    public class EfUpdateCustomerAccessCommand : EfUseCase, IUpdateCustomerAccessCommand
    {
        private UpdateCustomerAccessDTOValidator _validator;
        public EfUpdateCustomerAccessCommand(ShopContext context,
             UpdateCustomerAccessDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Modify customer access";

        public void Execute(UpdateCustomerAccessDTO data)
        {
            _validator.ValidateAndThrow(data);

            var userUseCases = Context.CustomerUseCases
                                      .Where(x => x.CustomerId == data.CustomerId)
                                      .ToList();

            Context.CustomerUseCases.RemoveRange(userUseCases);

            Context.CustomerUseCases.AddRange(data.UseCaseIds.Select(x =>
            new Domain.CustomerUseCase
            {
                CustomerId = data.CustomerId,
                UseCaseId = x
            }));

            Context.SaveChanges();
        }
    }
}
