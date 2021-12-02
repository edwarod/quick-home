using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Data.Repositories.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITypedBaseRepository<T>
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> GetAsync(int entityId, CancellationToken cancellationToken);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Add(IEnumerable<T> entities);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
