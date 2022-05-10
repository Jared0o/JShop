using AutoMapper;
using JShop.Core.Entities;
using JShop.Core.Entities.Identity;
using JShop.Core.Repositories;
using JShop.Infrastructure.Dto.Category;
using JShop.Infrastructure.Exceptions;
using JShop.Infrastructure.Services.Interfaces;
using JShop.Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;

namespace JShop.Infrastructure.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, UserManager<User> userManager, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task CreateAsync(CategoryRequest request, string userEmail)
        {
            await Validate(request);
            User user = await GetUser(userEmail);
            
            Category category = _mapper.Map<Category>(request);
            category.CreatedBy = user;

            await _categoryRepository.AddAsync(category);
        }

        public async Task DeleteAsync(int id, string userEmail)
        {
            Category category = await GetCategoryById(id);
            User user = await GetUser(userEmail);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IReadOnlyList<CategoryResponse>> GetAllAsync()
        {
            IReadOnlyList<Category> categories = await _categoryRepository.GetAllAsync();

            IReadOnlyList<CategoryResponse> responses = _mapper.Map<IReadOnlyList<CategoryResponse>>(categories);

            return responses;
        }

        public async Task<CategoryResponse> GetAsync(int id)
        {
            Category category = await GetCategoryById(id);
            CategoryResponse response = _mapper.Map<CategoryResponse>(category);

            return response;
        }

        public async Task UpdateAsync(int id, CategoryRequest request, string userEmail)
        {
            await Validate(request);
            Category category = await GetCategoryById(id);
            User user = await GetUser(userEmail);

            category.UpdatedBy = user;
            category.Name = request.Name;
            category.Description = request.Description;
            category.IsActive = request.IsActive;

            await _categoryRepository.UpdateAsync(category);
        }

        #region private metods
        private static async Task Validate(CategoryRequest request)
        {
            CategoryValidator validator = new CategoryValidator();
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

        private async Task<Category> GetCategoryById(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new NotFoundException($"Not found Category with id {id}");

            return category;
        }

        #endregion  
    }
}
