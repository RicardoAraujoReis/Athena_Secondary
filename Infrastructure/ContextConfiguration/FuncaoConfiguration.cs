using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class FuncaoConfiguration : IEntityTypeConfiguration<Funcao>
{
    public void Configure(EntityTypeBuilder<Funcao> builder)
    {
        builder.ToTable("Funcao");
        builder.HasKey(x => x.Fnc_identi);

        builder.Property(x => x.Fnc_descri).IsRequired().HasMaxLength(100).HasComment("Descrição da Função");
        builder.Property(x => x.Fnc_ativo).IsRequired().HasMaxLength(1).HasComment("Indica se a Função está ativa ou não (S - SIM / N - NÃO)");
        builder.Property(x => x.Fnc_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Fnc_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Fnc_usualt).HasMaxLength(10);
        builder.Property(x => x.Fnc_datcri).IsRequired();
        builder.Property(x => x.Fnc_datalt);

        builder.HasMany(x => x.DepFuncs)
            .WithOne(x => x.Funcao)
            .HasForeignKey(x => x.Dfc_fnc_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dfc_fnc_identi");
    }
}