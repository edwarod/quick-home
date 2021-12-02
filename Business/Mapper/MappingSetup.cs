using AutoMapper;
using QuickHome.Data.Models;
using QuickHome.Dto;

namespace QuickHome.Business.Mapper
{
    public class MappingSetup : Profile
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        public MappingSetup()
        {
            CreateMap<Lessee, LesseeDto>();

            CreateMap<LesseeDto, Lessee>()
                .ForMember(d => d.Rents, o => o.Ignore()); 
            
            CreateMap<Lessor, LessorDto>();

            CreateMap<LessorDto, Lessor>();

            CreateMap<Property, PropertyDto>();

            CreateMap<PropertyDto, Property>()
                .ForMember(d => d.Lessor, o => o.Ignore())
                .ForMember(d => d.Rents, o => o.Ignore());

            CreateMap<Rent, RentDto>();

            CreateMap<RentDto, Rent>()
                .ForMember(d => d.Lessee, o => o.Ignore())
                .ForMember(d => d.Property, o => o.Ignore());

        }
    }
}
