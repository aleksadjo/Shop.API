using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<int> ChildIds { get; set; }
    }
    public class UpdateCategoryDTO : CreateCategoryDTO
    {
        public int Id { get; set; }
    }

    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDTO> Children { get; set; }
    }
}
