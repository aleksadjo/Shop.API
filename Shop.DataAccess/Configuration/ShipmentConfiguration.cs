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
    internal class ShipmentConfiguration : EntityConfiguration<Shipment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Shipment> builder)
        {
            builder.Property(x => x.TrackingNumber).IsRequired();

            builder.HasMany(x => x.ShipmentItems)
                   .WithOne(x => x.Shipment)
                   .HasForeignKey(x =>  x.ShipmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
