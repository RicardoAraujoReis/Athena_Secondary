using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ContextConfiguration;

public class ComentariosAtendimentoPlantaoConfiguration : IEntityTypeConfiguration<ComentariosAtendimentoPlantao>
{
    public void Configure(EntityTypeBuilder<ComentariosAtendimentoPlantao> builder)
    {
        builder.ToTable("ComentariosAtendimentoPlantao", "Athena");
        builder.HasKey(x => x.Id);

        builder.Property(comentarios => comentarios.Cap_coment).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Cap_usubdd).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Cap_usucri).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Cap_usualt).HasMaxLength(10);
        builder.Property(x => x.Cap_datcri).IsRequired();
        builder.Property(x => x.Cap_datalt);

        builder.HasOne(x => x.Atendimento)
            .WithMany(x => x.Comentarios)
            .HasForeignKey(x => x.Cap_atd_identi)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("Cap_atd_identi");
    }
}
