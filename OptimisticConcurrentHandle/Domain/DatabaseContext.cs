using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OptimisticConcurrentHandle.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimisticConcurrentHandle.Domain
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): 
            base(options)
        {

        }

        public DbSet<User> User {  get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Pencil> Pencil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureDatabase();
        }
    }
}
