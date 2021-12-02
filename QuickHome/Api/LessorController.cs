using Microsoft.AspNetCore.Mvc;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Api
{
    [ApiController]
    [Route("api/lessor")]
    public class LessorController
    {
        private readonly ILessorDomainService _lessorDomainService;

        public LessorController(ILessorDomainService lessorDomainService)
        {
            _lessorDomainService = lessorDomainService;
        }

        [HttpGet]
        public Task<List<LessorDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _lessorDomainService.GetAllAsync(cancellationToken);
        }

        [HttpGet]
        [Route("{lessorId:int}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int lessorId, CancellationToken cancellationToken = default)
        {
            var lessor = await _lessorDomainService.GetByIdAsync(lessorId, cancellationToken);
            if (lessor == null)
            {
                return new NotFoundObjectResult("Lessor Not found.");
            }
            return new OkObjectResult(lessor);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] LessorDto lesseeDto, CancellationToken cancellationToken = default)
        {
            var lessor = await _lessorDomainService.CreateLessorAsync(lesseeDto, cancellationToken);
            return new CreatedResult($"/api/lessor/{lessor.ID}", lessor);
        }

        [HttpPut]
        [Route("{lessorId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int lessorId, [FromBody] LessorDto lesseeDto, CancellationToken cancellationToken = default)
        {
            var lessor = await _lessorDomainService.GetByIdAsync(lessorId, cancellationToken);
            if (lessor == null)
            {
                return new NotFoundObjectResult("Lessor Not found.");
            }
            lessor = await _lessorDomainService.UpdateLessorAsync(lessorId, lesseeDto, cancellationToken);
            return new OkObjectResult(lessor);
        }

        [HttpDelete]
        [Route("{lessorId:int}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int lessorId, CancellationToken cancellationToken = default)
        {
            var lessor = await _lessorDomainService.GetByIdAsync(lessorId, cancellationToken);
            if (lessor == null)
            {
                return new NotFoundObjectResult("Lessor Not found.");
            }
            await _lessorDomainService.DeleteLessorAsync(lessorId, cancellationToken);
            return new NoContentResult();
        }

    }
}
