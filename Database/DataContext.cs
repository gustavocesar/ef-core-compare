using Microsoft.EntityFrameworkCore;
using ef_core_compare.Entities;

namespace ef_core_compare.Database
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfCoreCompare;Trusted_Connection=True;");
        }

        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}