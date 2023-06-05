using BuberDinner.Domain.MenuAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuberDinner.Infra.Persistence;

public class BuberDinnerDbContext : DbContext
{
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

        // By default for the database never generate a primary key
        modelBuilder.Model.GetEntityTypes()
                          .SelectMany(e => e.GetProperties())
                          .Where(p => p.IsPrimaryKey())
                          .ToList()
                          .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}