using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Models.Dto.Image;
using ShoppingAPI.Services;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public ImageController(IImageService imageService, IMapper mapper)
        {
            this.imageService = imageService;
            this.mapper = mapper;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] AddImageDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var imageModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName).ToLower(),
                    FileSizeInByte = request.File.Length,
                    FileName = request.FileName,
                    Description = request.Description,
                    EntityType=request.EntityType,
                    ProductId=request.ProductId,
                };
                await imageService.UploadImageAsync(imageModel);

                return Ok(imageModel);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(AddImageDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported extension");
            }
            if (request.FileName.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload less size image.");
            }
        }
    }
}
