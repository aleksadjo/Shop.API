using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Configuration
{
    internal class OrderItemConfiguration : EntityConfiguration<OrderItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).HasPrecision(10,2).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(500).IsRequired();

            builder.HasMany(x => x.ShipmentItems)
                   .WithOne(x => x.OrderItem)
                   .HasForeignKey(x => x.OrderItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
