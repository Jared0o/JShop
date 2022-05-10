using JShop.Infrastructure.Dto.Brand;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JShop.Api.Controllers
{
    [Authorize(Policy = "AdminRoleRequire")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand(BrandRequest request)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _service.CreateBrandAsync(request, email);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandResponse>>> GetBrandList()
        {
            IReadOnlyList<BrandResponse> response = await _service.GetAllBrandAsync();

            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandResponse>> GetBrand([FromRoute]int id)
        {
            BrandResponse response = await _service.GetBrandAsync(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand([FromRoute]int id)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _service.DeleteBrandAsync(id, email);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateBrand([FromRoute]int id, [FromBody]BrandRequest request)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _service.UpdateBrandAsync(id, request, email);

            return Ok();
        }

    }
}
