using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public interface IImageService
    {
        Task<Image> GetImageByIdAsync(int id);
        Task<Image> UploadImageAsync(Image Image);
        Task UpdateImageAsync(Image Image);
        Task DeleteImageAsync(int id);
    }
}
