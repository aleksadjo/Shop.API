using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Configuration
{
    internal class CustomerPaymentMethodConfiguration : EntityConfiguration<CustomerPaymentMethod>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<CustomerPaymentMethod> builder)
        {
            builder.Property(x => x.CardNumber).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(500).IsRequired();
        }
    }
}
