using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> CreateProduct(Product Product);
        Task UpdateProduct(Product Product);
        Task DeleteProduct(int id);
    }
}
