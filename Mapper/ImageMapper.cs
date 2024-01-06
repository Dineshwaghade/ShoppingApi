using AutoMapper;
using ShoppingAPI.Models;
using ShoppingAPI.Models.Dto.Image;

namespace ShoppingAPI.Mapper
{
    public class ImageMapper : Profile
    {
        public ImageMapper()
        {
            CreateMap<AddImageDto, Image>();
            CreateMap<ImageDto, Image>().ReverseMap();
        }
    }
}