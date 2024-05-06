namespace Mulier.Infrastructure.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Mulier.Infrastructure.EntityFrameworkCore.Models;

internal class MulierDbContext : DbContext
{
    public DbSet<IngredientDbEntity> Ingredients { get; init; }

    public MulierDbContext(DbContextOptions<MulierDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IngredientDbEntity>(builder =>
        {
            builder.ToCollection("ingredients");
        });
    }
}
