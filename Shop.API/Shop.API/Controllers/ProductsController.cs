using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Products;
using Shop.Application.UseCases.Queries.Products;
using Shop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{id}")]
        public IActionResult Find(int id, [FromServices] IGetProductQuery query)
            => Ok(_handler.HandleQuery(query, id));

        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductsSearch search, [FromServices] ISearchProductsQuery query)
            => Ok(_handler.HandleQuery(query, search));


        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateImageProductDTO dto,
                                  [FromServices] ICreateImageProductCommand command)
        {
            _handler.HandleCommand(command, dto);

            return StatusCode(201);
        }
    }
}
