using Microsoft.EntityFrameworkCore;
using PizzaService.Data.Configurations;
using PizzaService.Models;

namespace PizzaService.Data
{
    public class PizzaDbContext(DbContextOptions<PizzaDbContext> options) : DbContext(options)
    {
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PizzaConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
