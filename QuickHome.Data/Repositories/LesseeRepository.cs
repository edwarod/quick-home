using Microsoft.EntityFrameworkCore;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Data.Repositories
{
    public class LesseeRepository : TypedBaseRepository<Lessee>, ILesseeRepository
    {
        /// <summary>
        /// Inherit doc
        /// </summary>
        public LesseeRepository(IQuickHomeContext context) : base(context) { }

        public override Task<Lessee> GetAsync(int entityId, CancellationToken cancellationToken)
        {
            return GetAll().SingleOrDefaultAsync(entity => entity.ID == entityId, cancellationToken);
        }
    }
}
