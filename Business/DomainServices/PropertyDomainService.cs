using AutoMapper;
using QuickHome.Business.DomainServices.Contracts;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using QuickHome.Dto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Business.DomainServices
{
    public class PropertyDomainService : IPropertyDomainService
    {

        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyDomainService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PropertyDto> CreatePropertyAsync(PropertyDto propertyDto, CancellationToken cancellationToken)
        {
            var property = _mapper.Map<Property>(propertyDto);
            _propertyRepository.Add(property);

            await _propertyRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<PropertyDto> UpdatePropertyAsync(int propertyId, PropertyDto propertyDto, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetAsync(propertyId, cancellationToken);

            property.Address = propertyDto.Address;
            property.Stratum = propertyDto.Stratum;
            property.Area = propertyDto.Area;
            property.Rooms = propertyDto.Rooms;
            property.Bathrooms = propertyDto.Bathrooms;
            property.ParkingSlots = propertyDto.ParkingSlots;
            property.HasElevator = propertyDto.HasElevator;
            property.Balconies = propertyDto.Balconies; 
            property.Appraisal = propertyDto.Appraisal;
            property.PropertyType = (Data.Models.PropertyType)propertyDto.PropertyType;
            property.SuggestedCanon = propertyDto.SuggestedCanon;

            await _propertyRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PropertyDto>(property);
        }

        public Task DeletePropertyAsync(int propertyDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
