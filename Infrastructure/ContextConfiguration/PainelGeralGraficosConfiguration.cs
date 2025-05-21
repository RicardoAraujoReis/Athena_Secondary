using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.PainelGeral;

namespace Infrastructure.ContextConfiguration;

internal class PainelGeralGraficosConfiguration : IEntityTypeConfiguration<PainelGeralGraficos>
{
    public void Configure(EntityTypeBuilder<PainelGeralGraficos> builder)
    {
        builder.ToTable("PainelGeralGraficos", "Athena");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeCliente).IsRequired().HasMaxLength(65);
        builder.Property(x => x.Quantidade).IsRequired();
        builder.Property(x => x.Mes).IsRequired();
        builder.Property(x => x.Ano).IsRequired();
    }
}
