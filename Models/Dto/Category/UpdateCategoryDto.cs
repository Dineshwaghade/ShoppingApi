using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models.Dto.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
