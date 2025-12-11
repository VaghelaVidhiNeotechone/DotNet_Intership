using Advanced_Repository_Operations___Asynchronous_Programming.Dtos;
using Advanced_Repository_Operations___Asynchronous_Programming.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advanced_Repository_Operations___Asynchronous_Programming.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
