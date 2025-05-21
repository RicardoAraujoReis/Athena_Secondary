using Athena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Data.EntityTypeConfiguration;

internal class AtendimentoPlantaoConfiguration : IEntityTypeConfiguration<AtendimentoPlantao>
{
    public void Configure(EntityTypeBuilder<AtendimentoPlantao> builder)
    {
        builder.ToTable("AtendimentoPlantao", "Athena");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Atd_identi");
        builder.Property(x => x.Atd_titulo).IsRequired().HasMaxLength(65).HasAnnotation("CustomAnnotation", "Título do Atendimento");
        builder.Property(x => x.Atd_tipatd).IsRequired().HasMaxLength(35).HasAnnotation("CustomAnnotation", "Tipo do Atendimento (DÚVIDA / SOLICITAÇÃO / PROBLEMA)");
        builder.Property(x => x.Atd_resumo).IsRequired().HasMaxLength(255).HasAnnotation("CustomAnnotation","Resumo do Tema");
        builder.Property(x => x.Atd_respn2).IsRequired().HasMaxLength(255).HasAnnotation("CustomAnnotation","Resposta do N2 ao Tema");
        builder.Property(x => x.Atd_crijir).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation","Indica se foi criado Jira a partir deste Atendimento (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_issue).HasMaxLength(35).HasAnnotation("CustomAnnotation","Número do JIRA");
        builder.Property(x => x.Atd_critic).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation","Criticidade do Tema (B - BAIXO / M - MÉDIO / A - ALTO / C - CRÍTICO)");
        builder.Property(x => x.Atd_resplt).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation","Tema resolvido no mesmo plantão? (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_ren1hm).HasMaxLength(1).HasAnnotation("CustomAnnotation","Resolveria se o N1 tivesse testado em HOM? (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_resn1).IsRequired().HasMaxLength(1).HasAnnotation("CustomAnnotation","Resolveria N1? (1 - SIM / 0 - NÃO)");
        builder.Property(x => x.Atd_evoln1).HasMaxLength(65).HasAnnotation("CustomAnnotation","Tema em que o N1 precisa evoluir");
        builder.Property(x => x.Atd_jusevo).HasMaxLength(255).HasAnnotation("CustomAnnotation","Observação");
        builder.Property(x => x.Atd_datatd).IsRequired().HasAnnotation("CustomAnnotation","Data do Plantão");
        builder.Property(x => x.Atd_nomal2).HasMaxLength(100).HasAnnotation("CustomAnnotation","Nome do analista N2 caso não seja o mesmo usuário a preencher o formulário");
        builder.Property(x => x.Atd_nomal1).HasMaxLength(100);
        builder.Property(x => x.Atd_status).IsRequired().HasMaxLength(35).HasAnnotation("CustomAnnotation","Status do Atendimento");
        builder.Property(x => x.Atd_catnv1).IsRequired().HasMaxLength(65);
        builder.Property(x => x.Atd_catnv2).IsRequired().HasMaxLength(65);
        builder.Property(x => x.Atd_catnv3).IsRequired().HasMaxLength(65);
        builder.Property(x => x.Atd_catnv4).HasMaxLength(65);
        builder.Property(x => x.Atd_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Atd_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Atd_usualt).HasMaxLength(10);
        builder.Property(x => x.Atd_datcri).IsRequired();
        builder.Property(x => x.Atd_datalt);
        builder.Property(x => x.Atd_linjir).HasMaxLength(255);
        builder.Property(x => x.Atd_verjir).HasMaxLength(65);
        builder.Property(x => x.Atd_usu_identi).IsRequired();
        builder.Property(x => x.Atd_cli_identi).IsRequired();
        builder.Property(x => x.Atd_jirarl).IsRequired().HasMaxLength(1);

        builder.HasOne(x => x.PreAtendimentoPlantao)
            .WithOne(x => x.AtendimentoPlantao)
            .HasForeignKey<AtendimentoPlantao>(x => x.Atd_ptd_identi)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("Atd_ptd_identi");

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.AtendimentosPlantao)
            .HasForeignKey(x => x.Atd_cli_identi)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("Atd_cli_identi");
    }
}