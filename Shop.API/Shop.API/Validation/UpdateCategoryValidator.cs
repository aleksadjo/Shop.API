using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;

namespace Shop.API.Validation
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        private ShopContext _context;
        public UpdateCategoryValidator(ShopContext context)
        {
            _context = context;
            RuleFor(x => x.ParentId).Must(ParentIdIsValid)
                                    .When(x => x.ParentId.HasValue)
                                    .WithMessage("Invalid parent id.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                                .Must((dto, n) => !context.Categories.Any(c => c.Name == n && dto.Id != c.Id))
                                .WithMessage("Name is already in use.");

            RuleFor(x => x.ChildIds).Must(AllChildrenExist).WithMessage("Invalid child categories.");
        }

        private bool ParentIdIsValid(UpdateCategoryDTO dto, int? parentId)
        {

            if (parentId == dto.Id)
            {
                return false;
            }

            return _context.Categories.Any(x => x.Id == parentId && x.IsActive);
        }

        private bool AllChildrenExist(UpdateCategoryDTO dto, IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }

            if (ids.Contains(dto.Id))
            {
                return false;
            }

            int brojIzBaze = _context.Categories.Count(x => x.IsActive && ids.Contains(x.Id));
            return brojIzBaze == ids.Count();
        }
    }
}
