using AutoMapper;
using ShoppingAPI.Models;
using ShoppingAPI.Models.Dto.Category;

namespace ShoppingAPI.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();

        }
    }
}
