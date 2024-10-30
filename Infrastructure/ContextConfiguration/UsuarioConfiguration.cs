using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(x => x.Usu_identi);

        builder.Property(x => x.Usu_descri).IsRequired().HasMaxLength(100).HasComment("Nome completo do Usuário");
        builder.Property(x => x.Usu_login).IsRequired().HasMaxLength(35).HasComment("Login do Usuário");
        builder.Property(x => x.Usu_senha).IsRequired().HasMaxLength(65).HasComment("Senha do Usuário");
        builder.Property(x => x.Usu_email).IsRequired().HasMaxLength(100).HasComment("E-mail do Usuário");
        builder.Property(x => x.Usu_ativo).IsRequired().HasMaxLength(1).HasComment("Indica se o Usuário está ativo ou não (S - SIM / N - NÃO)");
        builder.Property(x => x.Usu_status).IsRequired().HasMaxLength(1).HasComment("Indica se o Usuário está bloqueado (S - SIM / N - NÃO)");
        builder.Property(x => x.Usu_master).IsRequired().HasMaxLength(1).HasComment("Indica se o Usuário é super Usuário (S - SIM / N - NÃO)");
        builder.Property(x => x.Usu_tipusu).IsRequired().HasMaxLength(35).HasComment("Tipo do Usuário (N1 - 0, N2 - 1, ADM - 2)");
        builder.Property(x => x.Usu_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Usu_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Usu_usualt).HasMaxLength(10);
        builder.Property(x => x.Usu_datcri).IsRequired();
        builder.Property(x => x.Usu_datalt);

        builder.HasMany(x => x.PreAtendimentos)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.Ptd_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Ptd_usu_identi");

        builder.HasMany(x => x.Atendimentos)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.Atd_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Atd_usu_identi");

        builder.HasMany(x => x.DepFuncs)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.Dfc_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Dfc_usu_identi");

        builder.HasMany(x => x.UsuLhn)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.Uln_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Uln_usu_identi");
    }
}
