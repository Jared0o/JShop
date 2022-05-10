using JShop.Infrastructure.Dto.Category;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JShop.Api.Controllers
{
    [Authorize(Policy = "AdminRoleRequire")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CategoryRequest request)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _categoryService.CreateAsync(request, email);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryResponse>>> GetList()
        {
            IReadOnlyList<CategoryResponse> response = await _categoryService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetById([FromRoute]int id)
        {
            CategoryResponse response = await _categoryService.GetAsync(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _categoryService.DeleteAsync(id, email);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]CategoryRequest request)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            await _categoryService.UpdateAsync(id, request, email);

            return Ok();
        }
    }
}
