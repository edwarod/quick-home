using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Data.Repositories.Contracts;
using QuickHome.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices
{
    public class PropertySearchDomainService : IPropertySearchDomainService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertySearchDomainService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAll().Include(m => m.Lessor).ToListAsync(cancellationToken);
            return _mapper.Map<List<PropertyDto>>(properties);
        }

        public async Task<PropertyDto> SearchByIdAsync(int propertyId, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetIncludeLessorAsync(propertyId, cancellationToken);
            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<List<PropertyDto>> SearchByCriteriaAsync(PropertySearchCriteria propertySearchCriteria, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.SearchByCriteria(propertySearchCriteria, cancellationToken);
            return _mapper.Map<List<PropertyDto>>(properties);
        }

    }
}
