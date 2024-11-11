using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class TipoDadosListasConfiguration : IEntityTypeConfiguration<TipoDadosListas>
{
    public void Configure(EntityTypeBuilder<TipoDadosListas> builder)
    {
        builder.ToTable("TipoDadosListas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Tid_identi");
        builder.Property(x => x.Tid_descri).IsRequired().HasMaxLength(100).HasAnnotation("CustomAnnotation","Descrição do tipo de dados de listas");
        builder.Property(x => x.Tid_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Tid_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Tid_usualt).HasMaxLength(10);
        builder.Property(x => x.Tid_datcri).IsRequired();
        builder.Property(x => x.Tid_datalt);

        builder.HasMany(x => x.DadosListas)
            .WithOne(x => x.TipoDadosListas)
            .HasForeignKey(c => c.Dal_tid_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dal_tid_identi");
    }
}