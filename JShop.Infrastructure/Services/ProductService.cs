using AutoMapper;
using JShop.Core.Entities;
using JShop.Core.Entities.Identity;
using JShop.Core.Repositories;
using JShop.Infrastructure.Dto.Product;
using JShop.Infrastructure.Exceptions;
using JShop.Infrastructure.Services.Interfaces;
using JShop.Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;

namespace JShop.Infrastructure.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductReposiotry _productReposiotry;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductReposiotry productReposiotry, UserManager<User> userManager, IMapper mapper, ITaxRepository taxRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            _productReposiotry = productReposiotry;
            _userManager = userManager;
            _mapper = mapper;
            _taxRepository = taxRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(ProductRequest request, string userEmail)
        {
            await Validate(request);
            User user = await GetUser(userEmail);
            Product product = _mapper.Map<Product>(request);
            product.UpdatedBy = user;
            product.Name = product.Name.Trim();
            product.Slug = product.Name.Replace(' ', '-');

            Tax? tax = await _taxRepository.GetByIdAsync(request.TaxId ?? 0);
            if (tax != null)
                product.Tax = tax;

            Brand? brand = await _brandRepository.GetByIdAsync(request.BrandId ?? 0);
            if(brand != null)
                product.Brand = brand;

            Category? category = await _categoryRepository.GetByIdAsync(request.CategoryId ?? 0);
            if(category != null)
                product.Category = category;        
           
            await _productReposiotry.AddAsync(product);
        }

        public async Task DeleteAsync(int id, string userEmail)
        {
            Product product = await GetProductById(id);
            User user = await GetUser(userEmail);

            await _productReposiotry.DeleteAsync(product);
        }

        public async Task<IReadOnlyList<ProductResponse>> GetAllAsync()
        {
            IReadOnlyList<Product> products = await _productReposiotry.GetAllAsync();
            IReadOnlyList<ProductResponse> respons = _mapper.Map<IReadOnlyList<ProductResponse>>(products);

            return respons;
        }

        public async Task<ProductResponse> GetAsync(int id)
        {
            Product product = await GetProductById(id);
            ProductResponse response = _mapper.Map<ProductResponse>(product);

            return response;
        }

        public async Task UpdateAsync(int id, ProductRequest request, string userEmail)
        {
            //TODO
            throw new NotImplementedException();
        }

        #region private metods
        private static async Task Validate(ProductRequest request)
        {
            ProductValidator validator = new ProductValidator();
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

        private async Task<Product> GetProductById(int id)
        {
            Product? product = await _productReposiotry.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException($"Not found product with id {id}");

            return product;
        }

        #endregion 
    }
}
