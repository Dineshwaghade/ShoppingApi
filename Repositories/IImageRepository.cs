using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> GetImageById(int id);
        Task<Image> UploadImage(Image Image);
        Task UpdateImage(Image Image);
        Task DeleteImage(int id);
    }
}
