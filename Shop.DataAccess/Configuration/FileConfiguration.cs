using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Configuration
{
    internal class FileConfiguration : EntityConfiguration<Domain.File>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Domain.File> builder)
        {
            builder.Property(x => x.Path).IsRequired();
        }
    }
}
