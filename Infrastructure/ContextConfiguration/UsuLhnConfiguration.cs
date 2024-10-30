using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class UsuLhnConfiguration : IEntityTypeConfiguration<UsuLhn>
{
    public void Configure(EntityTypeBuilder<UsuLhn> builder)
    {
        builder.ToTable("UsuLhn");
        builder.HasKey(x => x.Uln_identi);

        builder.Property(x => x.Uln_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Uln_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Uln_usualt).HasMaxLength(10);
        builder.Property(x => x.Uln_datcri).IsRequired();
        builder.Property(x => x.Uln_datalt);

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuLhn)
            .HasForeignKey(c => c.Uln_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Uln_usu_identi");

        builder.HasOne(x => x.LinhaNegocio)
            .WithMany(x => x.UsuLhn)
            .HasForeignKey(c => c.Uln_lhn_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Uln_lhn_identi");
    }
}