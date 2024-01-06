using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Models.Dto.Product;
using ShoppingAPI.Services;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto)
        {
            var model = mapper.Map<Product>(addProductDto);
            var response = await productService.CreateProductAsync(model);

            return Ok(response);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product != null)
            {
                var model = mapper.Map<Product>(updateProductDto);
                model.Id = id;
                await productService.UpdateProductAsync(model);

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product != null)
            {
                await productService.DeleteProductAsync(id);

                return Ok();
            }

            return NotFound();
        }
    }
}
