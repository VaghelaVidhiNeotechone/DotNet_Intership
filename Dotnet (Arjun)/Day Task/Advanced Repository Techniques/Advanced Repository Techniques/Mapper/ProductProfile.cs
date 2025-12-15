using Advanced_Repository_Techniques.Dtos;
using Advanced_Repository_Techniques.Models;
using AutoMapper;

namespace Advanced_Repository_Techniques.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
