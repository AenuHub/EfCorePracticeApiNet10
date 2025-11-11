using AutoMapper;
using EfCorePracticeApiNet10.DTOs;
using EfCorePracticeApiNet10.Models;

namespace EfCorePracticeApiNet10.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
