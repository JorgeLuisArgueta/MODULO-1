
using FastDeliveriApi.Data.Configurations;
using FastDeliveriApi.Entity;
using Microsoft.EntityFrameworkCore;
namespace FastDeliveriApi.Data;
public class FastDeliveriDbContext : DbContext
{
    internal readonly object Customers;

    public FastDeliveriDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Custumer> custumers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration( new CustumerConfiguration());
    }
}