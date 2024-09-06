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
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(x => x.OrderCount, y => y.MapFrom(u => u.Orders.Count))
                .ForMember(x => x.ImagePath, y => y.MapFrom(u => u.Image.Path));
        }
    }
}
