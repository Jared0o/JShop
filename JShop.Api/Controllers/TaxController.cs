using JShop.Infrastructure.Dto.Tax;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JShop.Api.Controllers
{
    [Authorize(Policy = "AdminRoleRequire")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _service;

        public TaxController(ITaxService service)
        {
            _service = service;
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateTax(TaxRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _service.CreateTaxAsync(request, email);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TaxResponse>>> GetTaxList()
        {
            var response = await _service.GetAllTaxAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxResponse>> GetTax([FromRoute]int id)
        {
            var response = await _service.GetTaxAsync(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTax([FromRoute]int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _service.DeleteTaxAsync(id, email);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateTax([FromRoute]int id, [FromBody]TaxRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            await _service.UpdateTaxAsync(id, request, email);

            return Ok();
        }
    }
}
