using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Data.Repositories.Contracts;
using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QuickHome.Data.Models;

namespace QuickHome.Business.DomainServices
{
    public class LesseeDomainService : ILesseeDomainService
    {

        private readonly ILesseeRepository _lesseeRepository;
        private readonly IMapper _mapper;

        public LesseeDomainService(ILesseeRepository lesseeRepository, IMapper mapper)
        {
            _lesseeRepository = lesseeRepository;
            _mapper = mapper;
        }

        public async Task<List<LesseeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var lessees = await _lesseeRepository.GetAll().ToListAsync(cancellationToken);
            return _mapper.Map<List<LesseeDto>>(lessees);
        }

        public async Task<LesseeDto> GetByIdAsync(int lesseeId, CancellationToken cancellationToken)
        {
            var lessee = await _lesseeRepository.GetAsync(lesseeId, cancellationToken); 
            return _mapper.Map<LesseeDto>(lessee);
        }

        public async Task<LesseeDto> CreateLesseeAsync(LesseeDto lesseeDto, CancellationToken cancellationToken)
        {
            var lessee = _mapper.Map<Lessee>(lesseeDto);
            _lesseeRepository.Add(lessee);

            await _lesseeRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LesseeDto>(lessee);
        }

        public async Task<LesseeDto> UpdateLesseeAsync(int lesseeId, LesseeDto lesseeDto, CancellationToken cancellationToken)
        {
            var lessee = await _lesseeRepository.GetAsync(lesseeId, cancellationToken);

            lessee.FirstMidName = lesseeDto.FirstMidName;
            lessee.LastName = lesseeDto.LastName;
            lessee.BirthDate = lesseeDto.BirthDate;
            lessee.MonthlyIncome = lesseeDto.MonthlyIncome;

            await _lesseeRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LesseeDto>(lessee);
        }

        public async Task DeleteLesseeAsync(int lesseeId, CancellationToken cancellationToken)
        {
            var lessee = await _lesseeRepository.GetAsync(lesseeId, cancellationToken);
            _lesseeRepository.Delete(lessee);
            await _lesseeRepository.SaveChangesAsync(cancellationToken);
        }

    }
}
