using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.API.Core;
using Shop.API.Extensions;
using Shop.API.Validation;
using Shop.Application.DTO;
using Shop.Application.UseCases.Commands.Categories;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ShopContext _context;
        private IExceptionLogger _logger;
        private UseCaseHandler _handler;

        public CategoriesController(ShopContext context, IExceptionLogger logger, UseCaseHandler handler)
        {
            _context = context;
            _logger = logger;
            _handler = handler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search)
        {
            IQueryable<Category> query = _context.Categories.AsQueryable();

            if (search.WithChildren.HasValue)
            {
                if (search.WithChildren.Value)
                {
                    query = query.Where(c => c.Children.Any());
                }
                else
                {
                    query = query.Where(c => !c.Children.Any());
                }
            }

            if (search.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == search.ParentId);
            }

            if (search.Name.HasValue())
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower())); ;
            }

            List<CategoryDTO> categories = query.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category c = _context.Categories.Find(id);

            if (c == null)
            {
                return NotFound();
            }

            CategoryDTO dto = new()
            {
                Id = c.Id,
                Name = c.Name
            };

            this.FillChildCategories(dto);
            return Ok(dto);
        }

        private void FillChildCategories(CategoryDTO category)
        {

            List<CategoryDTO> listaChildova = new List<CategoryDTO>();

            int id = category.Id;

            category.Children = _context.Categories.Where(x => x.ParentId == id).Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();


            foreach (CategoryDTO child in category.Children)
            {
                FillChildCategories(child);
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromServices] ICreateCategoryCommand command,
                                  [FromBody] CreateCategoryDTO dto)
        {
            try
            {
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (ValidationException ex)
            {
                return UnprocessableEntity(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDTO dto, [FromServices] UpdateCategoryValidator validator)
        {
            try
            {
                dto.Id = id;

                Category c = _context.Categories.Include(x => x.Children).FirstOrDefault(x => x.Id == id);

                if (c == null)
                {
                    return NotFound();
                }

                var result = validator.Validate(dto);

                if (!result.IsValid)
                {
                    return result.ToUnprocessableEntity();
                }

                c.Name = dto.Name;
                c.ParentId = dto.ParentId;

                foreach (var child in c.Children)
                {
                    c.ParentId = null;
                }

                if (dto.ChildIds != null && dto.ChildIds.Any())
                {
                    List<Category> categories = _context.Categories.Where(x => dto.ChildIds.Contains(x.Id)).ToList();

                    c.Children = categories;
                }

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.Products.Any())
            {
                return Conflict(new { error = "Category contains products." });
            }

            if (category.Children.Any())
            {
                return Conflict(new { error = "Category contains child categories." });
            }

            _context.Categories.Remove(category);

            return NoContent();
        }
    }
}
