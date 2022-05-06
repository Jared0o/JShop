using AutoMapper;
using JShop.Core.Entities;
using JShop.Core.Entities.Identity;
using JShop.Infrastructure.Dto.Auth;
using JShop.Infrastructure.Dto.Tax;

namespace JShop.Infrastructure
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxRequest, Tax>();
            CreateMap<Tax, TaxResponse>();
        }
    }
}
