using AutoMapper;
using ShoppingAPI.Models;
using ShoppingAPI.Models.Dto.Product;

namespace ShoppingAPI.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<AddProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
