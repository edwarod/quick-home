using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using QuickHome.Dto;
using RentStatus = QuickHome.Data.Models.RentStatus;

namespace QuickHome.Business.DomainServices
{
    public class RentDomainService : IRentDomainService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMapper _mapper;
        private readonly INotificationDomainService _notificationDomainService;

        public RentDomainService(IRentRepository rentRepository, IMapper mapper, INotificationDomainService notificationDomainService)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
            _notificationDomainService = notificationDomainService;
        }

        public async Task<List<RentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var rents = await _rentRepository.GetAll().ToListAsync(cancellationToken);
            return _mapper.Map<List<RentDto>>(rents);
        }

        public async Task<RentDto> GetByIdAsync(int rentId, CancellationToken cancellationToken)
        {
            var rent = await _rentRepository.GetAsync(rentId, cancellationToken);
            return _mapper.Map<RentDto>(rent);
        }

        public async Task<RentDto> CreateRentalRequirementAsync(RentDto rentDto, CancellationToken cancellationToken)
        {
            var rent = _mapper.Map<Rent>(rentDto);
            rent.RentStatus = RentStatus.Optional;
            rent.RequirementDate = DateTime.Now;
            rent.DueDate = DateTime.Now.AddDays(3);
            _rentRepository.Add(rent);

            await _rentRepository.SaveChangesAsync(cancellationToken);

            rentDto = _mapper.Map<RentDto>(rent);

            _notificationDomainService.NotifyRentalRequirement(rentDto);

            return rentDto;
        }

        public async Task<RentDto> ApproveRentalRequirementAsync(int rentId, CancellationToken cancellationToken)
        {
            var rent = await _rentRepository.GetAsync(rentId, cancellationToken);
            rent.RentStatus = RentStatus.Approved;

            await _rentRepository.SaveChangesAsync(cancellationToken);

            var rentDto = _mapper.Map<RentDto>(rent);
            _notificationDomainService.NotifyRentalApproval(rentDto);
            return rentDto;
        }

        public async Task<RentDto> RejectRentalRequirementAsync(int rentId, CancellationToken cancellationToken)
        {
            var rent = await _rentRepository.GetAsync(rentId, cancellationToken);
            rent.RentStatus = RentStatus.Rejected;

            await _rentRepository.SaveChangesAsync(cancellationToken);

            var rentDto = _mapper.Map<RentDto>(rent);
            _notificationDomainService.NotifyRentalRejection(rentDto);
            return rentDto;
        }

    }
}
