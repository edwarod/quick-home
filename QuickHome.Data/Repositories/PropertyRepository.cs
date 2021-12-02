using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;
using QuickHome.Dto;
using RentStatus = QuickHome.Data.Models.RentStatus;

namespace QuickHome.Data.Repositories
{
    public class PropertyRepository : TypedBaseRepository<Property>, IPropertyRepository
    {        
        /// <summary>
        /// Inherit doc
        /// </summary>
        public PropertyRepository(IQuickHomeContext context) : base(context) { }

        public override Task<Property> GetAsync(int entityId, CancellationToken cancellationToken)
        {
            return GetAll().SingleOrDefaultAsync(entity => entity.PropertyID == entityId, cancellationToken);
        }

        public Task<Property> GetIncludeLessorAsync(int entityId, CancellationToken cancellationToken)
        {
            return GetAll().Include(p => p.Lessor).SingleOrDefaultAsync(entity => entity.PropertyID == entityId, cancellationToken);
        }

        public Task<List<Property>> SearchByCriteria(PropertySearchCriteria searchCriteria, CancellationToken cancellationToken)
        {
            var propertyQuery = GetAll().Include(p => p.Rents)
                .Where(p => p.Rents.All(r => r.RentStatus != RentStatus.Approved));

            if (searchCriteria.Stratum != null)
            {
                if (searchCriteria.Stratum.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Stratum >= searchCriteria.Stratum.Minimum.Value);
                }

                if (searchCriteria.Stratum.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Stratum <= searchCriteria.Stratum.Maximum.Value);
                }
            }

            if (searchCriteria.Area != null)
            {
                if (searchCriteria.Area.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Area >= searchCriteria.Area.Minimum.Value);
                }

                if (searchCriteria.Area.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Area <= searchCriteria.Area.Maximum.Value);
                }
            }

            if (searchCriteria.Rooms != null)
            {
                if (searchCriteria.Rooms.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Rooms >= searchCriteria.Rooms.Minimum.Value);
                }

                if (searchCriteria.Rooms.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Rooms <= searchCriteria.Rooms.Maximum.Value);
                }
            }

            if (searchCriteria.Bathrooms != null)
            {
                if (searchCriteria.Bathrooms.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Bathrooms >= searchCriteria.Bathrooms.Minimum.Value);
                }

                if (searchCriteria.Bathrooms.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Bathrooms <= searchCriteria.Bathrooms.Maximum.Value);
                }
            }

            if (searchCriteria.ParkingSlots != null)
            {
                if (searchCriteria.ParkingSlots.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.ParkingSlots >= searchCriteria.ParkingSlots.Minimum.Value);
                }

                if (searchCriteria.ParkingSlots.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.ParkingSlots <= searchCriteria.ParkingSlots.Maximum.Value);
                }
            }

            if (searchCriteria.HasElevator != null)
            {
                propertyQuery = propertyQuery.Where(p => p.HasElevator == searchCriteria.HasElevator);
            }

            if (searchCriteria.Balconies != null)
            {
                if (searchCriteria.Balconies.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Balconies >= searchCriteria.Balconies.Minimum.Value);
                }

                if (searchCriteria.Balconies.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Balconies <= searchCriteria.Balconies.Maximum.Value);
                }
            }

            if (searchCriteria.PropertyType != null)
            {
                var propertyType = (Models.PropertyType) searchCriteria.PropertyType.Value;
                propertyQuery = propertyQuery.Where(p => p.PropertyType == propertyType);
            }

            if (searchCriteria.SuggestedCanon != null)
            {
                if (searchCriteria.SuggestedCanon.Minimum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.SuggestedCanon >= searchCriteria.SuggestedCanon.Minimum.Value);
                }

                if (searchCriteria.SuggestedCanon.Maximum != null)
                {
                    propertyQuery = propertyQuery.Where(p => p.Bathrooms <= searchCriteria.SuggestedCanon.Maximum.Value);
                }
            }

            return propertyQuery.ToListAsync(cancellationToken);
        }
    }
}
