using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using Newtonsoft.Json;

namespace Shop.Application.DTO
{
    public class ProductsSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public List<SortBy> Sorts { get; set; } = new List<SortBy>();
    }

    public class SearchProductResult
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public string CreatedAtStr => CreatedAt.Humanize();
        public string MainImage { get; set; }
    }
}
