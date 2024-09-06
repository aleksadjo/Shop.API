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
    internal class OrderStatusConfiguration : EntityConfiguration<OrderStatus>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.Property(x => x.Status).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Orders)
                   .WithOne(x => x.OrderStatus)
                   .HasForeignKey(x => x.OrderStatusId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
