using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class LinhaNegocioConfiguration : IEntityTypeConfiguration<LinhaNegocio>
{
    public void Configure(EntityTypeBuilder<LinhaNegocio> builder)
    {
        builder.ToTable("LinhaNegocio");
        builder.HasKey(x => x.Lhn_identi);

        builder.Property(x => x.Lhn_descri).IsRequired().HasMaxLength(100).HasComment("Descrição da Linha de Negócio");
        builder.Property(x => x.Lhn_ativo).IsRequired().HasMaxLength(1).HasComment("Indica se a Linha de Negócio está ativa ou não (S - SIM / N - NÃO)");
        builder.Property(x => x.Lhn_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Lhn_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Lhn_usualt).HasMaxLength(10);
        builder.Property(x => x.Lhn_datcri).IsRequired();
        builder.Property(x => x.Lhn_datalt);

        builder.HasMany(x => x.Clientes)
            .WithOne(x => x.LinhaNegocio)
            .HasForeignKey(x => x.Cli_lhn_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Cli_lhn_identi");

        builder.HasMany(x => x.UsuLhn)
            .WithOne(x => x.LinhaNegocio)
            .HasForeignKey(x => x.Uln_lhn_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Uln_lhn_identi");
    }
}