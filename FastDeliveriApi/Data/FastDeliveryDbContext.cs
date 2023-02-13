using FastDeliveriApi.Data.Configurations;
using FastDeliveriApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace FastDeliveriApi.Data;
public class FastDeliveriDbContext : DbContext
{
    public FastDeliveriDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Customer> custumers { get; set; }
    public object Customers { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration( new CustumerConfiguration());
    }
}