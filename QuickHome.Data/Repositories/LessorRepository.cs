using Microsoft.EntityFrameworkCore;
using QuickHome.Data.Models;
using QuickHome.Data.Repositories.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Data.Repositories
{
    public class LessorRepository : TypedBaseRepository<Lessor>, ILessorRepository
    {
        /// <summary>
        /// Inherit doc
        /// </summary>
        public LessorRepository(IQuickHomeContext context) : base(context) { }

        public override Task<Lessor> GetAsync(int entityId, CancellationToken cancellationToken)
        {
            return GetAll().SingleOrDefaultAsync(entity => entity.ID == entityId, cancellationToken);
        }
    }
}
