using Athena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Data.EntityTypeConfiguration;

internal class CategoriaAtendimentoConfiguration : IEntityTypeConfiguration<CategoriaAtendimento>
{
    public void Configure(EntityTypeBuilder<CategoriaAtendimento> builder)
    {
        builder.ToTable("CategoriaAtendimento");
        builder.HasKey(x => x.Cat_identi);

        builder.Property(x => x.Cat_catpai).IsRequired().HasMaxLength(10).HasComment("ID da Categoria referência no nível anterior");
        builder.Property(x => x.Cat_nivel).IsRequired().HasMaxLength(1).HasComment("Nível da Categoria");
        builder.Property(x => x.Cat_valor).IsRequired().HasMaxLength(10).HasComment("Valor da Categoria");
        builder.Property(x => x.Cat_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Cat_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Cat_usualt).HasMaxLength(10);
        builder.Property(x => x.Cat_datcri).IsRequired();
        builder.Property(x => x.Cat_datalt);

        builder.HasMany(x => x.Atendimentos)
            .WithOne(x => x.CategoriaAtendimento)
            .HasForeignKey(x => x.Atd_cat_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Atd_cat_identi");
    }
}