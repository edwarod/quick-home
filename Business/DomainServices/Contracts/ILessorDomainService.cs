using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices.Contracts
{
    public interface ILessorDomainService
    {
        Task<List<LessorDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<LessorDto> GetByIdAsync(int lessorId, CancellationToken cancellationToken);
        Task<LessorDto> CreateLessorAsync(LessorDto lessorDto, CancellationToken cancellationToken);
        Task<LessorDto> UpdateLessorAsync(int lessorId, LessorDto lessorDto, CancellationToken cancellationToken);
        Task DeleteLessorAsync(int lessorId, CancellationToken cancellationToken);
    }
}
