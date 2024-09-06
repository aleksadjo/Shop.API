using FluentValidation;
using Shop.API.Validation;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Categories;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private CreateCategoryDTOValidator _validator;

        public EfCreateCategoryCommand(ShopContext context, CreateCategoryDTOValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => GetType().Name;

        public void Execute(CreateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);

            Category categoryToAdd = new Category
            {
                Name = data.Name,
                ParentId = data.ParentId
            };

            Context.Categories.Add(categoryToAdd);

            var childCategories = Context.Categories
                                          .Where(c => data.ChildIds.Contains(c.Id))
                                          .ToList();

            categoryToAdd.Children = childCategories;

            Context.SaveChanges();
        }
    }
}
