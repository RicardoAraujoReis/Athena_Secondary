using Athena.Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class ComentariosAtendimentoPlantao : BaseEntity<int>
{
    public string Cap_coment { get; set; }
    public int Cap_usucri { get; set; }
    public string Cap_usubdd { get; set; }
    public int? Cap_usualt { get; set; }
    public DateTime Cap_datcri { get; set; }
    public DateTime? Cap_datalt { get; set; }
    public int Cap_atd_identi { get; set; }
    public virtual AtendimentoPlantao Atendimento { get; set; }

    public ComentariosAtendimentoPlantao UpdateComentariosAtendimentoPlantao(
        int id,
        string cap_coment,
        string cap_usubdd,
        int cap_usucri,
        int cap_usualt,
        DateTime cap_datcri,
        DateTime? cap_datalt
    )
    {
        Id = id;
        Cap_coment = cap_coment;
        Cap_usubdd = cap_usubdd;
        Cap_usucri = cap_usucri;
        Cap_usualt = cap_usualt;
        Cap_datcri = cap_datcri;
        Cap_datalt = cap_datalt;

        return this;
    }
}
