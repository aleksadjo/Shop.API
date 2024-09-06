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
    internal class PaymentMethodConfiguration : EntityConfiguration<PaymentMethod>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.Property(x => x.Method).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Method).IsUnique();

            builder.HasMany(x => x.CustomerPaymentMethods)
                   .WithOne(x => x.PaymentMethod)
                   .HasForeignKey(x => x.PaymentMethodId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
