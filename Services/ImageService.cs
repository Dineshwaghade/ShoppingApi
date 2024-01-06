using ShoppingAPI.Models;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task DeleteImageAsync(int id)
        {
            await imageRepository.DeleteImage(id);
        }

        public async Task<Image> GetImageByIdAsync(int id)
        {
            return await imageRepository.GetImageById(id);
        }

        public async Task UpdateImageAsync(Image Image)
        {
            await imageRepository.UpdateImage(Image);
        }

        public async Task<Image> UploadImageAsync(Image Image)
        {
            return await imageRepository.UploadImage(Image);
        }
    }
}
