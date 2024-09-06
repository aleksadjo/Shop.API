using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.Validators
{
    public class UpdateCustomerAccessDTOValidator : AbstractValidator<UpdateCustomerAccessDTO>
    {
        private static int updateUserAccessId = 4;
        public UpdateCustomerAccessDTOValidator(ShopContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.CustomerId)
                    .Must(x => context.Customers.Any(u => u.Id == x && u.IsActive))
                    .WithMessage("Requested customer doesn't exist.")
                    .Must(x => !context.CustomerUseCases.Any(u => u.UseCaseId == updateUserAccessId && u.CustomerId == x))
                    .WithMessage("Not allowed to change this user.");

            RuleFor(x => x.UseCaseIds)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId)).WithMessage("Invalid usecase id range.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");


        }
    }
}
