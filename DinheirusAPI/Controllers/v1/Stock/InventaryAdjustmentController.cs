using AutoMapper;
using Domain.Interface.Service.Stock;
using Domain.Model.Common;
using Domain.Model.Stock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1.Stock
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryAdjustmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInventoryAdjustmentService _service;
        public InventoryAdjustmentController(IInventoryAdjustmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<InventoryAdjustmentResponse>> GetInventoryAdjustments()
        {
            var teste = await _service.Get();
            return await _service.Get();
        }

        [HttpGet("option-items")]
        [Authorize]
        public async Task<IEnumerable<OptionItemResponse>> GetInventoryAdjustmentsToSelectOption()
        {
            return _mapper.Map<List<OptionItemResponse>>(await _service.Get());
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<InventoryAdjustmentResponse>> GetInventoryAdjustments(Guid uuid)
        {
            var data = await _service.Get(uuid);
            return data;
        }


        [HttpPost]
        public async Task<ActionResult<InventoryAdjustmentResponse>> PostInventoryAdjustment([FromBody] InventoryAdjustmentRequest request)
        {
            var newInventoryAdjustment = await _service.Create(request);
            return CreatedAtAction(nameof(GetInventoryAdjustments), new { uuid = newInventoryAdjustment.Uuid }, newInventoryAdjustment);
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
        public async Task<ActionResult> PutInventoryAdjustment(Guid uuid, [FromBody] InventoryAdjustmentRequest request)
        {
            if (uuid != request.Uuid)
                return BadRequest();

            await _service.Update(uuid, request);

            return NoContent();
        }
    }
}
