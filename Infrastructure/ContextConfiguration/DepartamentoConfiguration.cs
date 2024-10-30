using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");
        builder.HasKey(x => x.Dpt_identi);

        builder.Property(x => x.Dpt_descri).IsRequired().HasMaxLength(100).HasComment("Nome do Departamento");
        builder.Property(x => x.Dpt_ativo).IsRequired().HasMaxLength(1).HasComment("Indica se o Departamento está ativo ou não (S - SIM / N - NÃO)");
        builder.Property(x => x.Dpt_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Dpt_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Dpt_usualt).HasMaxLength(10);
        builder.Property(x => x.Dpt_datcri).IsRequired();
        builder.Property(x => x.Dpt_datalt);

        builder.HasMany(x => x.DepFuncs)
            .WithOne(x => x.Departamento)
            .HasForeignKey(x => x.Dfc_dpt_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dfc_dpt_identi");
    }
}