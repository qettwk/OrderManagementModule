using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public class OrderDbContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DbSet<Domain.Order> Orders { get; set; }
        public DbSet<AutomobileCountInOrder> automobileCountInOrders { get; set; }

        // разные schemas
        // прописывать ли вручную связи?


        public OrderDbContext(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Order>()
            .ToTable("Orders", "OrderManagment");
            modelBuilder.Entity<AutomobileCountInOrder>()
            .ToTable("AutomobileCountInOrder", "OrderManagment");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("AppDatabase"));
        }

    }
}
