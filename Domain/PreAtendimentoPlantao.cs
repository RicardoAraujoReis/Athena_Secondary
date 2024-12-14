using Models.Interfaces;

namespace Athena.Models;

public class PreAtendimentoPlantao : BaseEntity<int>
{    
    public DateTime Ptd_datptd { get; set; }        
    public int Ptd_usu_identi { get; set; }        
    public int Ptd_cli_identi { get; set; }                
    public String Ptd_tipptd { get; set; }
    public String Ptd_critic { get; set; }
    public String Ptd_resumo {get; set; }
    public String? Ptd_numcha { get; set; }
    public String Ptd_jirarl { get; set; }
    public String? Ptd_numjir { get; set; }
    public String? Ptd_diagn1 { get; set; }
    public String Ptd_status { get; set; }
    public String? Ptd_reton2 { get; set; }
    public String? Ptd_observ { get; set; }        
    public String Ptd_nomal1 { get; set; }
    public int? Ptd_numatd { get; set; }
    public String Ptd_usubdd { get; set; }
    public DateTime Ptd_datcri { get; set; }
    public DateTime? Ptd_datalt { get; set; }
    public int Ptd_usucri { get; set; }
    public int? Ptd_usualt { get; set; }
    public virtual Usuario Usuario { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual AtendimentoPlantao AtendimentoPlantao { get; set; }
    
    public PreAtendimentoPlantao UpdatePreAtendimentoPlantao(
        int id,
        DateTime ptd_datptd,
        int ptd_usu_identi,
        int ptd_cli_identi,
        String ptd_tipptd,
        String ptd_critic,
        String ptd_resumo,
        String ptd_numcha,
        String ptd_jirarl,
        String ptd_numjir,
        String ptd_diagn1,
        String ptd_status,
        String ptd_reton2,
        String ptd_observ,
        String ptd_nomal1,
        int ptd_numatd,
        String ptd_usubdd,
        DateTime ptd_datcri,
        DateTime ptd_datalt,
        int ptd_usucri,
        int ptd_usualt
    )
    {
        Id = id;
        Ptd_datptd = ptd_datptd;
        Ptd_usu_identi = ptd_usu_identi;
        Ptd_cli_identi = ptd_cli_identi;
        Ptd_tipptd = ptd_tipptd;
        Ptd_critic = ptd_critic;
        Ptd_resumo = ptd_resumo;
        Ptd_numcha = ptd_numcha;
        Ptd_jirarl = ptd_jirarl;
        Ptd_numjir = ptd_numjir;
        Ptd_diagn1 = ptd_diagn1;
        Ptd_status = ptd_status;
        Ptd_reton2 = ptd_reton2;
        Ptd_observ = ptd_observ;
        Ptd_nomal1 = ptd_nomal1;
        Ptd_numatd = ptd_numatd;
        Ptd_usubdd = ptd_usubdd;
        Ptd_datcri = ptd_datcri;
        Ptd_datalt = ptd_datalt;
        Ptd_usucri = ptd_usucri;
        Ptd_usualt = ptd_usualt;

        return this;
    }
}
