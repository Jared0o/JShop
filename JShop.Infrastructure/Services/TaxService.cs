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

        public async Task CreateTax(TaxRequest request, string userEmail)
        {
            TaxValidator validator = new TaxValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                throw new UserNotValidException("Please try log in again");

            Tax tax = _mapper.Map<Tax>(request);
            tax.CreatedBy = user;
            tax.CreatedAt = DateTime.Now;

            await _taxRepository.AddAsync(tax);
        }

        public Task DeleteTax(int taxId, string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TaxResponse>> GetAllTax()
        {
            throw new NotImplementedException();
        }

        public Task<TaxResponse> GetTax(int tax)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTax(int id, TaxRequest request, string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
