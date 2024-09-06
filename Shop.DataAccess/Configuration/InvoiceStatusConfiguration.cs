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
    internal class InvoiceStatusConfiguration : EntityConfiguration<InvoiceStatus>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<InvoiceStatus> builder)
        {
            builder.Property(x => x.Status).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Invoices)
                   .WithOne(x => x.InvoiceStatus)
                   .HasForeignKey(x => x.InvoiceStatusId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
