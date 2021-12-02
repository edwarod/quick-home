using QuickHome.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices.Contracts
{
    public interface IPropertyDomainService
    {
        Task<PropertyDto> CreatePropertyAsync(PropertyDto propertyDto, CancellationToken cancellationToken);
        Task<PropertyDto> UpdatePropertyAsync(int propertyId, PropertyDto propertyDto, CancellationToken cancellationToken);
        Task DeletePropertyAsync(int propertyDto, CancellationToken cancellationToken);
    }
}
