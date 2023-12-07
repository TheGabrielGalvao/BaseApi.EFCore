using Domain.Interface.Service.Financial;
using Domain.Model.Financial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1.Financial
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManualTransactionController : ControllerBase
    {

        private readonly IFinancialReleaseService _service;
        private readonly IManualTransactionService _manualTransactionService;
        public ManualTransactionController(IFinancialReleaseService service, IManualTransactionService manualTransactionService)
        {
            _service = service;
            _manualTransactionService = manualTransactionService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<FinancialReleaseResponse>> GetFinancialReleases()
        {
            return await _service.Get();
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<FinancialReleaseResponse>> GetFinancialReleases(Guid uuid)
        {
            return await _service.Get(uuid);
        }


        [HttpPost]
        public async Task<ActionResult<ManualTransactionResponse>> PostManualTransaction([FromBody] ManualTransactionRequest transaction)
        {
            var newFinancialRelease = await _manualTransactionService.Create(transaction);
            return Ok(newFinancialRelease);
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            var transactionDelete = await _service.Get(uuid);
            if (transactionDelete == null)
                return NotFound();

            await _service.Delete(uuid);
            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult> PutFinancialRelease(Guid uuid, [FromBody] FinancialReleaseRequest transaction)
        {
            if (uuid != transaction.Uuid)
                return BadRequest();

            await _service.Update(uuid, transaction);

            return NoContent();
        }
    }
}
