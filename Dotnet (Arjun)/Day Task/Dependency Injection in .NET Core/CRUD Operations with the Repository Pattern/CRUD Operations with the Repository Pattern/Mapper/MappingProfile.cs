using AutoMapper;
using CRUD_Operations_with_the_Repository_Pattern.Dtos;
using CRUD_Operations_with_the_Repository_Pattern.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD_Operations_with_the_Repository_Pattern.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity → DTO
            CreateMap<Product, ProductDto>();

            // DTO → Entity
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
