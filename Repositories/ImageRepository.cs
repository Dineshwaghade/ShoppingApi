using ShoppingAPI.Data;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApiDbContext apiDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImageRepository(ApiDbContext apiDbContext,IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
        {
            this.apiDbContext = apiDbContext;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Image> UploadImage(Image image)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            await apiDbContext.Images.AddAsync(image);
            await apiDbContext.SaveChangesAsync();
            return image;
        }

        public async Task DeleteImage(int id)
        {
            var image = await apiDbContext.Images.FindAsync(id);
            apiDbContext.Images.Remove(image);
            apiDbContext.SaveChanges();
        }

        public async Task<Image> GetImageById(int id)
        {
            return await apiDbContext.Images.FindAsync(id);
        }

        public async Task UpdateImage(Image image)
        {
            var model = await apiDbContext.Images.FindAsync(image.Id);
            apiDbContext.Images.Update(model);
            apiDbContext.SaveChanges();
        }
    }
}
