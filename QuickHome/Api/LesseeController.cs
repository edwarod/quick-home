using Microsoft.AspNetCore.Mvc;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Api
{
    [ApiController]
    [Route("api/lessee")]
    public class LesseeController
    {
        private readonly ILesseeDomainService _lesseeDomainService;

        public LesseeController(ILesseeDomainService lesseeDomainService)
        {
            _lesseeDomainService = lesseeDomainService;
        }

        [HttpGet]
        public Task<List<LesseeDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _lesseeDomainService.GetAllAsync(cancellationToken);
        }
        
        [HttpGet]
        [Route("{lesseeId:int}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int lesseeId, CancellationToken cancellationToken = default)
        {
            var lessee = await _lesseeDomainService.GetByIdAsync(lesseeId, cancellationToken);
            if (lessee == null)
            {
                return new NotFoundObjectResult("Lessee Not found.");
            }
            return new OkObjectResult(lessee);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] LesseeDto lesseeDto, CancellationToken cancellationToken = default)
        {
            var lessee = await _lesseeDomainService.CreateLesseeAsync(lesseeDto, cancellationToken);
            return new CreatedResult($"/api/lessee/{lessee.ID}", lessee);
        }

        [HttpPut]
        [Route("{lesseeId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int lesseeId, [FromBody] LesseeDto lesseeDto, CancellationToken cancellationToken = default)
        {
            var lessee = await _lesseeDomainService.GetByIdAsync(lesseeId, cancellationToken);
            if (lessee == null)
            {
                return new NotFoundObjectResult("Lessee Not found.");
            }
            lessee = await _lesseeDomainService.UpdateLesseeAsync(lesseeId, lesseeDto, cancellationToken);
            return new OkObjectResult(lessee);
        }

        [HttpDelete]
        [Route("{lesseeId:int}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int lesseeId, CancellationToken cancellationToken = default)
        {
            var lessee = await _lesseeDomainService.GetByIdAsync(lesseeId, cancellationToken);
            if (lessee == null)
            {
                return new NotFoundObjectResult("Lessee Not found.");
            }
            await _lesseeDomainService.DeleteLesseeAsync(lesseeId, cancellationToken);
            return new NoContentResult();
        }

    }
}
