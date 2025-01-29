using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Athena.Models;

namespace Athena.Data.EntityTypeConfiguration;

internal class PreAtendimentoPlantaoConfiguration : IEntityTypeConfiguration<PreAtendimentoPlantao>
{
    public void Configure(EntityTypeBuilder<PreAtendimentoPlantao> builder)
    {
        builder.ToTable("PreAtendimentoPlantao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Ptd_identi");
        builder.Property(x => x.Ptd_datptd).IsRequired().HasAnnotation("CustomAnnotation","Data do Pré Atendimento");
        builder.Property(x => x.Ptd_tipptd).IsRequired().HasMaxLength(35).HasAnnotation("CustomAnnotation","Tipo do Pré Atendimento (DÚVIDA / SOLICITAÇÃO / PROBLEMA)");
        builder.Property(x => x.Ptd_critic).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation","Criticidade do Tema (B - BAIXO / M - MÉDIO / A - ALTO / C - CRÍTICO)");
        builder.Property(x => x.Ptd_resumo).IsRequired().HasMaxLength(255).HasAnnotation("CustomAnnotation","Resumo do Tema");
        builder.Property(x => x.Ptd_numcha).HasMaxLength(35).HasAnnotation("CustomAnnotation","Número do chamado");
        builder.Property(x => x.Ptd_jirarl).HasMaxLength(1).HasAnnotation("CustomAnnotation","Existe Jira relacionado? (S - SIM / N - NÃO)");
        builder.Property(x => x.Ptd_numjir).HasMaxLength(35).HasAnnotation("CustomAnnotation","Número do Jira");
        builder.Property(x => x.Ptd_diagn1).HasMaxLength(255).HasAnnotation("CustomAnnotation","Análise realizada pelo N1");
        builder.Property(x => x.Ptd_status).HasMaxLength(35).HasAnnotation("CustomAnnotation","Status do Pré Atendimento");
        builder.Property(x => x.Ptd_reton2).HasMaxLength(255).HasAnnotation("CustomAnnotation","Resposta do N2");
        builder.Property(x => x.Ptd_observ).HasMaxLength(255).HasAnnotation("CustomAnnotation","Observação");
        builder.Property(x => x.Ptd_nomal1).HasMaxLength(100).HasAnnotation("CustomAnnotation","Nome do analista N1 caso não seja o mesmo usuário a preencher o formulário");
        builder.Property(x => x.Ptd_numatd).HasMaxLength(10).HasAnnotation("CustomAnnotation","Número do Atendimento gerado (se houver)");
        builder.Property(x => x.Ptd_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Ptd_usucri).IsRequired();
        builder.Property(x => x.Ptd_usualt).HasMaxLength(10);
        builder.Property(x => x.Ptd_datcri).IsRequired();
        builder.Property(x => x.Ptd_datalt);

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.PreAtendimentos)
            .HasForeignKey(x => x.Ptd_usu_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Ptd_usu_identi");

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.PreAtendimentos)
            .HasForeignKey(x => x.Ptd_cli_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Ptd_cli_identi");

        builder.HasOne(x => x.AtendimentoPlantao)
            .WithOne(x => x.PreAtendimentoPlantao)
            .HasForeignKey<AtendimentoPlantao>(x => x.Atd_ptd_identi)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("Atd_ptd_identi");
    }
}