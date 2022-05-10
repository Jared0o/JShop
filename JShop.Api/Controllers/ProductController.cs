using JShop.Infrastructure.Dto.Product;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JShop.Api.Controllers
{
    [Authorize(Policy = "AdminRoleRequire")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductRequest request)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _productService.CreateAsync(request, email);

            return Ok();
        }
    }
}
