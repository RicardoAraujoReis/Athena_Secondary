using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class DadosListasConfiguration : IEntityTypeConfiguration<DadosListas>
{
    public void Configure(EntityTypeBuilder<DadosListas> builder)
    {
        builder.ToTable("DadosListas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Dal_identi");
        builder.Property(x => x.Dal_valor).IsRequired().HasMaxLength(100).HasAnnotation("CustomAnnotation","Valor a ser exibido no campo de lista");
        builder.Property(x => x.Dal_tid_descri).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Dal_aplicacao).IsRequired().HasMaxLength(65);
        builder.Property(x => x.Dal_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Dal_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Dal_usualt).HasMaxLength(10);
        builder.Property(x => x.Dal_datcri).IsRequired();
        builder.Property(x => x.Dal_datalt);

        builder.HasOne(x => x.TipoDadosListas)
            .WithMany(x => x.DadosListas)
            .HasForeignKey(c => c.Dal_tid_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dal_tid_identi");
    }
}