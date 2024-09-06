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
    internal class InvoiceConfiguration : EntityConfiguration<Invoice>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.Details).HasMaxLength(500).IsRequired();

            builder.HasMany(x => x.Shipments)
                   .WithOne(x => x.Invoice)
                   .HasForeignKey(x => x.InvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Payments)
                   .WithOne(x => x.Invoice)
                   .HasForeignKey(x => x.InvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
