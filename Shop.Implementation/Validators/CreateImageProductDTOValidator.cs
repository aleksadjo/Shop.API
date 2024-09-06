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
    public class CreateImageProductDTOValidator : AbstractValidator<CreateImageProductDTO>
    {
        public CreateImageProductDTOValidator(ShopContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.")
                .Must(x => context.Categories.Any(c => c.Id == x && c.IsActive))
                .WithMessage("Provided category doesn't exist.");

            RuleFor(x => x.Images).NotEmpty()
                    .WithMessage("At least one image is required.")
                    .DependentRules(() =>
                    {
                        RuleForEach(x => x.Images).Must((x, fileName) =>
                        {
                            var path = Path.Combine("wwwroot", "temp", fileName);

                            var exists = Path.Exists(path);

                            return exists;
                        }).WithMessage("File doesn't exist.");
                    });
        }
    }
}
