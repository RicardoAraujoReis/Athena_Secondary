using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class DepFuncConfiguration : IEntityTypeConfiguration<DepFunc>
{
    public void Configure(EntityTypeBuilder<DepFunc> builder)
    {
        builder.ToTable("DepFunc");
        builder.HasKey(x => x.Dfc_identi);

        builder.Property(x => x.Dfc_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Dfc_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Dfc_usualt).HasMaxLength(10);
        builder.Property(x => x.Dfc_datcri).IsRequired();
        builder.Property(x => x.Dfc_datalt);

        builder.HasOne(x => x.Departamento)
            .WithMany(x => x.DepFuncs)
            .HasForeignKey(x => x.Dfc_dpt_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dfc_dpt_identi");

        builder.HasOne(x => x.Funcao)
            .WithMany(x => x.DepFuncs)
            .HasForeignKey(x => x.Dfc_fnc_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dfc_fnc_identi");

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.DepFuncs)
            .HasForeignKey(x => x.Dfc_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dfc_usu_identi");

    }
}