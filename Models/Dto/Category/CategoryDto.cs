using ShoppingAPI.Models.Dto.Product;

namespace ShoppingAPI.Models.Dto.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}