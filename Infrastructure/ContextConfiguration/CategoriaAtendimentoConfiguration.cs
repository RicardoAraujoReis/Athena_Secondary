using Athena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Data.EntityTypeConfiguration;

internal class CategoriaAtendimentoConfiguration : IEntityTypeConfiguration<CategoriaAtendimento>
{
    public void Configure(EntityTypeBuilder<CategoriaAtendimento> builder)
    {
        builder.ToTable("CategoriaAtendimento");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Cat_identi");
        builder.Property(x => x.Cat_catpai).IsRequired().HasMaxLength(10).HasAnnotation("CustomAnnotation", "ID da Categoria referência no nível anterior");
        builder.Property(x => x.Cat_nivel).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation", "Nível da Categoria");
        builder.Property(x => x.Cat_valor).IsRequired().HasMaxLength(10).HasAnnotation("CustomAnnotation", "Valor da Categoria");
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