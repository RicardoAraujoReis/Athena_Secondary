using Athena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Data.EntityTypeConfiguration;

internal class AtendimentoPlantaoConfiguration : IEntityTypeConfiguration<AtendimentoPlantao>
{
    public void Configure(EntityTypeBuilder<AtendimentoPlantao> builder)
    {
        builder.ToTable("AtendimentoPlantao", "Athena");
        builder.HasKey(x => x.Atd_identi);

        builder.Property(x => x.Atd_tipatd).IsRequired().HasMaxLength(35).HasComment("Tipo do Atendimento (DÚVIDA / SOLICITAÇÃO / PROBLEMA)");
        builder.Property(x => x.Atd_resumo).IsRequired().HasMaxLength(255).HasComment("Resumo do Tema");
        builder.Property(x => x.Atd_respn2).IsRequired().HasMaxLength(255).HasComment("Resposta do N2 ao Tema");
        builder.Property(x => x.Atd_crijir).IsRequired().HasMaxLength(1).HasComment("Indica se foi criado Jira a partir deste Atendimento (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_issue).IsRequired().HasMaxLength(35).HasComment("Número do JIRA");
        builder.Property(x => x.Atd_critic).IsRequired().HasMaxLength(1).HasComment("Criticidade do Tema (B - BAIXO / M - MÉDIO / A - ALTO / C - CRÍTICO)");
        builder.Property(x => x.Atd_resplt).IsRequired().HasMaxLength(1).HasComment("Tema resolvido no mesmo plantão? (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_ren1hm).IsRequired().HasMaxLength(1).HasComment("Resolveria se o N1 tivesse testado em HOM? (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_resn1).IsRequired().HasMaxLength(1).HasComment("Resolveria N1? (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_evoln1).HasMaxLength(65).HasComment("Tema em que o N1 precisa evoluir");
        builder.Property(x => x.Atd_observ).HasMaxLength(255).HasComment("Observação");
        builder.Property(x => x.Atd_datatd).IsRequired().HasComment("Data do Plantão");
        builder.Property(x => x.Atd_nomal2).HasMaxLength(100).HasComment("Nome do analista N2 caso não seja o mesmo usuário a preencher o formulário");
        builder.Property(x => x.Atd_status).IsRequired().HasMaxLength(35).HasComment("Status do Atendimento");
        builder.Property(x => x.Atd_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Atd_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Atd_usualt).HasMaxLength(10);
        builder.Property(x => x.Atd_datcri).IsRequired();
        builder.Property(x => x.Atd_datalt);

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Atendimentos)
            .HasForeignKey(x => x.Atd_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Atd_usu_identi");

        builder.HasOne(x => x.PreAtendimentoPlantao)
            .WithOne(x => x.AtendimentoPlantao)
            .HasForeignKey<AtendimentoPlantao>(x => x.Atd_ptd_identi)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("Atd_ptd_identi");

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.Atendimentos)
            .HasForeignKey(x => x.Atd_cli_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Atd_cli_identi");

        builder.HasOne(x => x.CategoriaAtendimento)
            .WithMany(x => x.Atendimentos)
            .HasForeignKey(x => x.Atd_cat_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Atd_cat_identi");
    }
}