using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Dto;

namespace QuickHome.Api
{
    [ApiController]
    [Route("api/property")]
    public class PropertyController
    {
        private readonly IPropertyDomainService _propertyDomainService;
        private readonly IPropertySearchDomainService _propertySearchDomainService;

        public PropertyController(IPropertyDomainService propertyDomainService, IPropertySearchDomainService propertySearchDomainService)
        {
            _propertyDomainService = propertyDomainService;
            _propertySearchDomainService = propertySearchDomainService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] PropertyDto propertyDto, CancellationToken cancellationToken = default)
        {
            var property = await _propertyDomainService.CreatePropertyAsync(propertyDto, cancellationToken);
            return new CreatedResult($"/api/property/search/{property.PropertyID}", property);
        }

        [HttpPut]
        [Route("{propertyId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int propertyId, [FromBody] PropertyDto propertyDto, CancellationToken cancellationToken = default)
        {
            
            var property = await _propertySearchDomainService.SearchByIdAsync(propertyId, cancellationToken);
            if (property == null)
            {
                return new NotFoundObjectResult("Property Not found.");
            }
            property = await _propertyDomainService.UpdatePropertyAsync(propertyId, propertyDto, cancellationToken);
            return new OkObjectResult(property);
        }

    }
}
