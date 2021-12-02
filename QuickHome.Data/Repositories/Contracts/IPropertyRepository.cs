using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QuickHome.Data.Models;
using QuickHome.Dto;

namespace QuickHome.Data.Repositories.Contracts
{
    public interface IPropertyRepository : ITypedBaseRepository<Property>
    {
        Task<Property> GetIncludeLessorAsync(int entityId, CancellationToken cancellationToken);

        Task<List<Property>> SearchByCriteria(PropertySearchCriteria searchCriteria, CancellationToken cancellationToken);

    }
}
