using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Models.Dto.Category;
using ShoppingAPI.Services;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await categoryService.GetAllCategoriesAsync();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto addCategoryDto)
        {
            var model = mapper.Map<Category>(addCategoryDto);
            var category = await categoryService.CreateCategoryAsync(model);
            var response = mapper.Map<CategoryDto>(category);

            return Ok(response);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var model = mapper.Map<Category>(updateCategoryDto);
            model.Id = id;
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category != null)
            {
                await categoryService.UpdateCategoryAsync(model);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category != null)
            {
                await categoryService.DeleteCategoryAsync(id);

                return NoContent();
            }

            return NotFound();
        }
    }
}
