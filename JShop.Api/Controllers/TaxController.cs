using JShop.Infrastructure.Dto.Tax;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JShop.Api.Controllers
{
    [Authorize(Policy = "UserRoleRequire")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _service;

        public TaxController(ITaxService service)
        {
            _service = service;
        }

        [Authorize(Policy = "AdminRoleRequire")]
        [HttpPost]
        public async Task<ActionResult> CreateTax(TaxRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _service.CreateTax(request, email);
            return Ok();
        }
    }
}
