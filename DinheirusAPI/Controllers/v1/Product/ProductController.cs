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
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            return await _service.Get();
        }

        [HttpGet("option-items")]
        [Authorize]
        public async Task<IEnumerable<OptionItemResponse>> GetProductsToSelectOption()
        {
            return _mapper.Map<List<OptionItemResponse>>(await _service.Get());
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<ProductResponse>> GetProducts(Guid uuid)
        {
            var data = await _service.Get(uuid);
            return data;
        }


        [HttpPost]
        public async Task<ActionResult<ProductResponse>> PostProduct([FromBody] ProductRequest request)
        {
            var newProduct = await _service.Create(request);
            return CreatedAtAction(nameof(GetProducts), new { uuid = newProduct.Uuid }, newProduct);
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
        public async Task<ActionResult> PutProduct(Guid uuid, [FromBody] ProductRequest request)
        {
            if (uuid != request.Uuid)
                return BadRequest();

            await _service.Update(uuid, request);

            return NoContent();
        }
    }
}
