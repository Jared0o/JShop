using AutoMapper;
using JShop.Core.Entities;
using JShop.Core.Entities.Identity;
using JShop.Core.Repositories;
using JShop.Infrastructure.Dto.Brand;
using JShop.Infrastructure.Exceptions;
using JShop.Infrastructure.Services.Interfaces;
using JShop.Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;

namespace JShop.Infrastructure.Services
{
    internal class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, UserManager<User> userManager, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task CreateBrandAsync(BrandRequest request, string userEmail)
        {
            await ValidateBrand(request);
            User user = await GetUser(userEmail);

            Brand brand = _mapper.Map<Brand>(request);
            brand.CreatedBy = user;
            await _brandRepository.AddAsync(brand);
        }

        public async Task DeleteBrandAsync(int id, string userEmail)
        {
            User user = await GetUser(userEmail);
            Brand brand = await GetBrandById(id);

            await _brandRepository.DeleteAsync(brand);
        }

        public async Task<IReadOnlyList<BrandResponse>> GetAllBrandAsync()
        {
            IReadOnlyList<Brand> brands = await _brandRepository.GetAllAsync();

            IReadOnlyList<BrandResponse> response = _mapper.Map<IReadOnlyList<BrandResponse>>(brands);

            return response;
        }

        public async Task<BrandResponse> GetBrandAsync(int id)
        {
            Brand brand = await GetBrandById(id);

            BrandResponse response = _mapper.Map<BrandResponse>(brand);

            return response;
        }

        public async Task UpdateBrandAsync(int id, BrandRequest request, string userEmail)
        {
            await ValidateBrand(request);
            Brand brand = await GetBrandById(id);
            User user = await GetUser(userEmail);
            
            brand.UpdatedBy = user;
            brand.Description = request.Description;
            brand.IsActive = request.IsActive;
            brand.Name = request.Name;

            await _brandRepository.UpdateAsync(brand);
        }

        #region private metods
        private static async Task ValidateBrand(BrandRequest request)
        {
            BrandValidator validator = new BrandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);
        }

        private async Task<User> GetUser(string userEmail)
        {
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                throw new UserNotValidException("Please try log in again");

            return user;
        }

        private async Task<Brand> GetBrandById(int id)
        {
            Brand? brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                throw new NotFoundException($"Not found brand with id {id}");

            return brand;
        }

        #endregion  
    }
}
