using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Cli_identi");
        builder.Property(x => x.Cli_descri).IsRequired().HasMaxLength(100).HasAnnotation("CustomAnnotation", "Descrição do Cliente");
        builder.Property(x => x.Cli_ativo).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation", "Indica se o Cliente está ativo ou não (S - SIM / N - NÃO)");
        builder.Property(x => x.Cli_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Cli_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Cli_usualt).HasMaxLength(10);
        builder.Property(x => x.Cli_datcri).IsRequired();
        builder.Property(x => x.Cli_datalt);

        builder.HasOne(x => x.LinhaNegocio)
            .WithMany(x => x.Clientes)
            .HasForeignKey(x => x.Cli_lhn_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Cli_lhn_identi");

        builder.HasMany(x => x.Atendimentos)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.Atd_cli_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Atd_cli_identi");

        builder.HasMany(x => x.PreAtendimentos)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.Ptd_cli_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Ptd_cli_identi");
    }
}