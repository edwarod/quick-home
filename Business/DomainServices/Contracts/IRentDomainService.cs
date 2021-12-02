using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QuickHome.Dto;

namespace QuickHome.Business.DomainServices.Contracts
{

    public interface IRentDomainService
    {
        Task<List<RentDto>> GetAllAsync(CancellationToken cancellationToken);

        Task<RentDto> GetByIdAsync(int rentId, CancellationToken cancellationToken);

        Task<RentDto> CreateRentalRequirementAsync(RentDto rentDto, CancellationToken cancellationToken);

        Task<RentDto> ApproveRentalRequirementAsync(int rentId, CancellationToken cancellationToken);

        Task<RentDto> RejectRentalRequirementAsync(int rentId, CancellationToken cancellationToken);

    }
}
