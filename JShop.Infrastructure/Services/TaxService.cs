using AutoMapper;
using JShop.Core.Entities;
using JShop.Core.Entities.Identity;
using JShop.Core.Repositories;
using JShop.Infrastructure.Dto.Tax;
using JShop.Infrastructure.Exceptions;
using JShop.Infrastructure.Services.Interfaces;
using JShop.Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;

namespace JShop.Infrastructure.Services
{
    internal class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public TaxService(ITaxRepository taxRepository, UserManager<User> userManager, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateTaxAsync(TaxRequest request, string userEmail)
        {
            await ValidateRequest(request);

            User user = await GetUser(userEmail);

            Tax tax = _mapper.Map<Tax>(request);
            tax.CreatedBy = user;

            await _taxRepository.AddAsync(tax);
        }

        public async Task DeleteTaxAsync(int taxId, string userEmail)
        {
            User user = await GetUser(userEmail);

            Tax tax = await GetTaxByIdAsync(taxId);

            await _taxRepository.DeleteAsync(tax);
        }

        public async Task<IReadOnlyList<TaxResponse>> GetAllTaxAsync()
        {
            IReadOnlyList<Tax> texes = await _taxRepository.GetAllAsync();

            IReadOnlyList<TaxResponse> response = _mapper.Map<IReadOnlyList<TaxResponse>>(texes);
            
            return response;
        }

        public async Task<TaxResponse> GetTaxAsync(int id)
        {
            Tax tax = await GetTaxByIdAsync(id);

            TaxResponse response = _mapper.Map<TaxResponse>(tax);

            return response;
        }

        public async Task UpdateTaxAsync(int id, TaxRequest request, string userEmail)
        {
            await ValidateRequest(request);

            User user = await GetUser(userEmail);

            Tax tax = await GetTaxByIdAsync(id);

            tax.Name = request.Name;
            tax.Value = request.Value;
            tax.UpdatedBy = user;
            tax.UpdatedAt = DateTime.Now;
            
            await _taxRepository.UpdateAsync(tax);               
        }

        #region Private metods

        private async Task<User> GetUser(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new UserNotValidException("Please try log in again");

            return user;
        }
        
        private async Task<Tax> GetTaxByIdAsync(int id)
        {
            Tax? tax = await _taxRepository.GetByIdAsync(id);
            if (tax == null)
                throw new NotFoundException($"Not Found tax with id {id}");

            return tax;
        }

        private async Task ValidateRequest(TaxRequest request)
        {
            TaxValidator validator = new TaxValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);
        }

        #endregion
    }
}



