using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.Models.Dto.Image
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FilePath { get; set; }
        public string FileExension { get; set; }
        public long FileSizeInByte { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string EntityType { get; set; }
    }
}
