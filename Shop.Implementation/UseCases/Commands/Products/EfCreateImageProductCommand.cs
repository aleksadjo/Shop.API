using FluentValidation;
using Shop.Application;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Products;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.UseCases.Commands.Products
{
    public class EfCreateImageProductCommand : EfUseCase, ICreateImageProductCommand
    {
        private readonly CreateImageProductDTOValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateImageProductCommand(ShopContext context, CreateImageProductDTOValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "Create image product";

        public void Execute(CreateImageProductDTO data)
        {
            _validator.ValidateAndThrow(data);

            foreach (var file in data.Images)
            {
                var tempFile = Path.Combine("wwwroot", "temp", file);
                var destinationFile = Path.Combine("wwwroot", "products", file);
                System.IO.File.Move(tempFile, destinationFile);
            }

            ImageProduct product = new ImageProduct
            {
                Name = data.Name,
                CategoryId = data.CategoryId.Value,
                Images = data.Images.Select(x => new ImageProductFile
                {
                    File = new Domain.File
                    {
                        Path = x,
                        Type = FileType.Image
                    }
                }).ToList()
            };

            Context.ImageProducts.Add(product);

            Context.SaveChanges();
        }
    }
}
