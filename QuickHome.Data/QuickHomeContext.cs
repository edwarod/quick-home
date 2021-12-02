using Microsoft.EntityFrameworkCore;
using QuickHome.Data.Models;
using System.Linq;

namespace QuickHome.Data
{
    public class QuickHomeContext : DbContext, IQuickHomeContext
    {

        public QuickHomeContext(DbContextOptions<QuickHomeContext> options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Lessor> Lessors { get; set; }
        public DbSet<Lessee> Lessees { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Rent> Rents { get; set; }


        public IQueryable<T> GetAll<T>() where T : class
        {
            return Set<T>();
        }

        public void Add<T>(object entity) where T : class
        {
            var enumerableEntity = entity as System.Collections.IEnumerable;
            if (enumerableEntity != null)
            {
                foreach (var ent in enumerableEntity)
                {
                    AddCore<T>(ent);
                }
            }
            else
            {
                AddCore<T>(entity);
            }
        }

        private void AddCore<T>(object entity) where T : class
        {
            var state = Entry(entity).State;
            if (state == EntityState.Detached)
            {
                Set<T>().Add(entity as T);
            }
        }

        public void Delete<T>(object entity) where T : class
        {
            var enumerableEntity = entity as System.Collections.IEnumerable;
            if (enumerableEntity != null)
            {
                foreach (var ent in (enumerableEntity).Cast<object>().ToList())
                {
                    Set<T>().Remove(ent as T);
                }
            }
            else
            {
                Set<T>().Remove(entity as T);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(r => r.Lessor)
                .WithMany(r => r.Properties);
            modelBuilder.Entity<Property>().ToTable("Property");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Property)
                .WithMany(r => r.Rents)
                .IsRequired(false);
            modelBuilder.Entity<Rent>().ToTable("Rent");
        }

    }
}
