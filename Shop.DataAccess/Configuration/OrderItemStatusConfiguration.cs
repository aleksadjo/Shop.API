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
    internal class OrderItemStatusConfiguration : EntityConfiguration<OrderItemStatus>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OrderItemStatus> builder)
        {
            builder.Property(x => x.Status).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.OrderItemStatus)
                   .HasForeignKey(x => x.OrderItemStatusId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
