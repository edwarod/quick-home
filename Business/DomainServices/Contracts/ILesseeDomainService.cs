using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices.Contracts
{
    public interface ILesseeDomainService
    {
        Task<List<LesseeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<LesseeDto> GetByIdAsync(int lesseeId, CancellationToken cancellationToken);
        Task<LesseeDto> CreateLesseeAsync(LesseeDto lesseeDto, CancellationToken cancellationToken);
        Task<LesseeDto> UpdateLesseeAsync(int lesseeId, LesseeDto lesseeDto, CancellationToken cancellationToken);
        Task DeleteLesseeAsync(int lesseeId, CancellationToken cancellationToken);
    }
}
