using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Customers;
using Shop.Application.UseCases.Queries;
using Shop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CustomerController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterCustomerDTO dto, [FromServices] IRegisterCustomerCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CustomerSearch search, [FromServices] IGetCustomersQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));

        // PUT /api/users/5/access
        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateCustomerAccessDTO dto,
                                                  [FromServices] IUpdateCustomerAccessCommand command)
        {
            dto.CustomerId = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}
