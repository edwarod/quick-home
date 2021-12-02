using Microsoft.EntityFrameworkCore;
using QuickHome.Data.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuickHome.Data
{
    public interface IQuickHomeContext
    {
        DbSet<Property> Properties { get; set; }
        DbSet<Lessor> Lessors { get; set; }
        DbSet<Lessee> Lessees { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<Rent> Rents { get; set; }

        IQueryable<T> GetAll<T>() where T : class;

        void Add<T>(object entity) where T : class;

        void Delete<T>(object entity) where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
