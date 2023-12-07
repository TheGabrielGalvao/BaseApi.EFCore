using AutoMapper;
using Domain.Interface.Service.Product;
using Domain.Model.Common;
using Domain.Model.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1.Product
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _service;
        public ProductCategoryController(IProductCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ProductCategoryResponse>> GetProductCategorys()
        {
            return await _service.Get();
        }

        [HttpGet("option-items")]
        [Authorize]
        public async Task<IEnumerable<OptionItemResponse>> GetProductCategorysToSelectOption()
        {
            return _mapper.Map<List<OptionItemResponse>>(await _service.Get());
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<ProductCategoryResponse>> GetProductCategorys(Guid uuid)
        {
            return await _service.Get(uuid);
        }


        [HttpPost]
        public async Task<ActionResult<ProductCategoryResponse>> PostProductCategory([FromBody] ProductCategoryRequest request)
        {
            var newProductCategory = await _service.Create(request);
            return CreatedAtAction(nameof(GetProductCategorys), new { uuid = newProductCategory.Uuid }, newProductCategory);
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            var userDelete = await _service.Get(uuid);
            if (userDelete == null)
                return NotFound();

            await _service.Delete(uuid);
            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult> PutProductCategory(Guid uuid, [FromBody] ProductCategoryRequest request)
        {
            if (uuid != request.Uuid)
                return BadRequest();

            await _service.Update(uuid, request);

            return NoContent();
        }
    }
}
