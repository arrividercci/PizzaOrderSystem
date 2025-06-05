using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Models;

namespace OrderService.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.PizzaId).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(i => i.Order).WithMany(o => o.Items).HasForeignKey(i => i.OrderId);
        }
    }
}
