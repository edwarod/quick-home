using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices.Contracts
{
    public interface IPropertySearchDomainService
    {
        Task<List<PropertyDto>> GetAllAsync( CancellationToken cancellationToken);
        Task<PropertyDto> SearchByIdAsync(int propertyId, CancellationToken cancellationToken);
        Task<List<PropertyDto>> SearchByCriteriaAsync(PropertySearchCriteria propertySearchCriteria, CancellationToken cancellationToken);
    }
}
