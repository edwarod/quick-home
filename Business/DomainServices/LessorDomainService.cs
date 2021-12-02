using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices
{
    public class LessorDomainService : ILessorDomainService
    {
        private readonly ILessorRepository _lessorRepository;
        private readonly IMapper _mapper;

        public LessorDomainService(ILessorRepository lessorRepository, IMapper mapper)
        {
            _lessorRepository = lessorRepository;
            _mapper = mapper;
        }

        public async Task<List<LessorDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var lessors = await _lessorRepository.GetAll().ToListAsync(cancellationToken);
            return _mapper.Map<List<LessorDto>>(lessors);
        }

        public async Task<LessorDto> GetByIdAsync(int lessorId, CancellationToken cancellationToken)
        {
            var lessor = await _lessorRepository.GetAsync(lessorId, cancellationToken);
            return _mapper.Map<LessorDto>(lessor);
        }

        public async Task<LessorDto> CreateLessorAsync(LessorDto lessorDto, CancellationToken cancellationToken)
        {
            var lessor = _mapper.Map<Lessor>(lessorDto);
            _lessorRepository.Add(lessor);

            await _lessorRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LessorDto>(lessor);
        }

        public async Task<LessorDto> UpdateLessorAsync(int lessorId, LessorDto lessorDto, CancellationToken cancellationToken)
        {
            var lessor = await _lessorRepository.GetAsync(lessorId, cancellationToken);

            lessor.FirstMidName = lessorDto.FirstMidName;
            lessor.LastName = lessorDto.LastName;
            lessor.BirthDate = lessorDto.BirthDate;

            await _lessorRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LessorDto>(lessor);
        }

        public async Task DeleteLessorAsync(int lessorId, CancellationToken cancellationToken)
        {
            var lessor = await _lessorRepository.GetAsync(lessorId, cancellationToken);
            _lessorRepository.Delete(lessor);
            await _lessorRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
