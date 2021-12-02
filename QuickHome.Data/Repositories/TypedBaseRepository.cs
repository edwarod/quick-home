using QuickHome.Data.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Data.Repositories
{
    /// <summary>
    /// inherit doc
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TypedBaseRepository<T> : ITypedBaseRepository<T> where T : class
    {
        /// <summary>
        /// inherit doc
        /// </summary>
        protected readonly IQuickHomeContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected TypedBaseRepository(IQuickHomeContext context)
        {
            Context = context;
        }

        /// <summary>
        /// can be overridden 
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return Context.GetAll<T>();
        }

        /// <summary>
        /// leave this to the implementor
        /// implementation is usually:
        /// return GetAll().SingleOrDefault(rp => rp.Id == entityId);
        /// </summary>
        /// <returns></returns>
        public abstract Task<T> GetAsync(int entityId, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            Context.Add<T>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Add(IEnumerable<T> entities)
        {
            Context.Add<T>(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            Context.Delete<T>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            Context.Delete<T>(entities);
        }

        /// <summary>
        /// Asynchronous SaveChanges
        /// </summary>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
