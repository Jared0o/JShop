using AutoMapper;
using JShop.Core.Entities;
using JShop.Infrastructure.Dto.Brand;
using JShop.Infrastructure.Dto.Category;
using JShop.Infrastructure.Dto.Product;
using JShop.Infrastructure.Dto.Tax;

namespace JShop.Infrastructure
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxRequest, Tax>();
            CreateMap<Tax, TaxResponse>();
            CreateMap<Brand, BrandResponse>();
            CreateMap<BrandRequest, Brand>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
