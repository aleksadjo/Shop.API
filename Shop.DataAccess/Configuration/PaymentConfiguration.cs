using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Configuration
{
    internal class PaymentConfiguration : EntityConfiguration<Payment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.Amount).HasPrecision(10,2).IsRequired();
        }
    }
}
