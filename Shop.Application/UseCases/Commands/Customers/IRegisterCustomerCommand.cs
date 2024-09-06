using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UseCases.Commands.Customers
{
    public interface IRegisterCustomerCommand : ICommand<RegisterCustomerDTO>
    {
    }
}
