﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Configuration
{
    public class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.UseCaseName).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => new { x.Username, x.UseCaseName, x.ExecutedAt })
                   .IncludeProperties(x => x.UseCaseData);
        }
    }
}
