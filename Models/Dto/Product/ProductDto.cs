using ShoppingAPI.Models.Dto.Category;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.Models.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
