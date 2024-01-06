using ShoppingAPI.Models;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Product> CreateProductAsync(Product Product)
        {
            return await productRepository.CreateProduct(Product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await productRepository.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await productRepository.GetProductById(id);
        }

        public async Task UpdateProductAsync(Product Product)
        {
            await productRepository.UpdateProduct(Product);
        }
    }
}
