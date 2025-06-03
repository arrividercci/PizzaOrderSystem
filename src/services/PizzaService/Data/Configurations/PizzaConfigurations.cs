using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaService.Models;

namespace PizzaService.Data.Configurations
{
    public class PizzaConfigurations : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable(nameof(Pizza));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Category).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ImageUrl).HasMaxLength(200);
        }
    }
}
