using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.Models.Dto.Image
{
    public class AddImageDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public string EntityType { get; set; }
    }
}
