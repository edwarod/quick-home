using Microsoft.EntityFrameworkCore;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Data.Repositories
{
    public class RentRepository : TypedBaseRepository<Rent>, IRentRepository
    {
        /// <summary>
        /// Inherit doc
        /// </summary>
        public RentRepository(IQuickHomeContext context) : base(context) { }

        public override Task<Rent> GetAsync(int entityId, CancellationToken cancellationToken)
        {
            return GetAll().SingleOrDefaultAsync(entity => entity.RentID == entityId, cancellationToken);
        }
    }
}
