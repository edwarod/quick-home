using Microsoft.AspNetCore.Mvc;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Api
{
    [ApiController]
    [Route("api/property/search")]
    public class PropertySearchController
    {
        private readonly IPropertySearchDomainService _propertySearchDomainService;

        public PropertySearchController(IPropertySearchDomainService propertySearchDomainService)
        {
            _propertySearchDomainService = propertySearchDomainService;
        }

        [HttpGet]
        public Task<List<PropertyDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _propertySearchDomainService.GetAllAsync(cancellationToken);
        }

        [HttpGet]
        [Route("{propertyId:int}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int propertyId, CancellationToken cancellationToken = default)
        {
            var property = await _propertySearchDomainService.SearchByIdAsync(propertyId, cancellationToken);
            if (property == null)
            {
                return new NotFoundObjectResult("Property Not found.");
            }
            return new OkObjectResult(property);
        }


        [HttpPost]
        public async Task<ActionResult> GetBySearchCriterieaAsync([FromBody] PropertySearchCriteria searchCriteria, CancellationToken cancellationToken = default)
        {
            var property = await _propertySearchDomainService.SearchByCriteriaAsync(searchCriteria, cancellationToken);
            return new OkObjectResult(property);
        }

    }
}
