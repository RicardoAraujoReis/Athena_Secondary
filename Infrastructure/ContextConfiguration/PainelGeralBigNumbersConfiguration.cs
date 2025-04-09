using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ContextConfiguration;

internal class PainelGeralBigNumbersConfiguration : IEntityTypeConfiguration<PainelGeralBigNumbers>
{
    public void Configure(EntityTypeBuilder<PainelGeralBigNumbers> builder)
    {
        builder.ToTable("PainelGeralBigNumbers", "Athena");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Icon).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.Label).IsRequired().HasMaxLength(65);
        builder.Property(x => x.DataAtualizacao).IsRequired();
    }
}
