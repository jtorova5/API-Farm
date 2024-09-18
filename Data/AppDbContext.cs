using API_Farm.Models;
using Microsoft.EntityFrameworkCore;
using API_Farm.Seeders;

namespace API_Farm.Data;

public class AppDbContext : DbContext
{
    // define DbSets for entities
    public DbSet<AnimalType> AnimalTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        AnimalTypeSeeder.Seed(modelBuilder);
    }
}
