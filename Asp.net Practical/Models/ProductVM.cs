using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.net_Practical.Models
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
