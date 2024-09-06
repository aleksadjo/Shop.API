using AutoMapper;
using Shop.Application.DTO;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ImageProduct, SearchProductResult>()
                .ForMember(x => x.MainImage, y => y.MapFrom(p => p.Images.First().File.Path));

            CreateMap<ImageProduct, ProductDTO>()
                .ForMember(x => x.Price, y => y.MapFrom(p => p.Price))
                .ForMember(x => x.Images, y => y.MapFrom(p => p.Images.Select(x => x.File.Path)))
                .ForMember(x => x.CategoryName, y => y.MapFrom(p => p.Category.Name))
                .ForMember(x => x.Name, y => y.MapFrom(p => p.Name));
        }
    }
}
