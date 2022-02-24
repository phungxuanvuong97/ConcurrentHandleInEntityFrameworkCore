using Microsoft.EntityFrameworkCore;

namespace OptimisticConcurrentHandle.Domain.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pencil>()
                .Property(x => x.RowVersion)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
