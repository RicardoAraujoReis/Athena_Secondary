using Models.Interfaces;

namespace Athena.Models;

public class PreAtendimentoPlantao : BaseEntity<int>
{    
    public DateTime Ptd_datptd { get; set; }        
    public int Ptd_usu_identi { get; set; }        
    public int Ptd_cli_identi { get; set; }                
    public string Ptd_tipptd { get; set; }
    public string Ptd_critic { get; set; }
    public string Ptd_resumo {get; set; }
    public string? Ptd_numcha { get; set; }
    public string? Ptd_jirarl { get; set; }
    public string? Ptd_numjir { get; set; }
    public string? Ptd_diagn1 { get; set; }
    public string Ptd_status { get; set; }
    public string? Ptd_reton2 { get; set; }
    public string? Ptd_observ { get; set; }        
    public string Ptd_nomal1 { get; set; }
    public int? Ptd_numatd { get; set; }
    public string Ptd_usubdd { get; set; }
    public DateTime Ptd_datcri { get; set; }
    public DateTime? Ptd_datalt { get; set; }
    public int Ptd_usucri { get; set; }
    public int? Ptd_usualt { get; set; }
    public string? Ptd_linjir { get; set; }
    public string? Ptd_verjir { get; set; }
    public virtual Usuario Usuario { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual AtendimentoPlantao AtendimentoPlantao { get; set; }
    
    public PreAtendimentoPlantao UpdatePreAtendimentoPlantao(
        int id,
        DateTime ptd_datptd,
        int ptd_usu_identi,
        int ptd_cli_identi,
        string ptd_tipptd,
        string ptd_critic,
        string ptd_resumo,
        string ptd_numcha,
        string ptd_jirarl,
        string ptd_numjir,
        string ptd_diagn1,
        string ptd_status,
        string ptd_reton2,
        string ptd_observ,
        string ptd_nomal1,
        int ptd_numatd,
        string ptd_usubdd,
        DateTime ptd_datcri,
        DateTime ptd_datalt,
        int ptd_usucri,
        int ptd_usualt,
        string ptd_linjir,
        string ptd_verjir
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
        Ptd_linjir = ptd_linjir;
        Ptd_verjir = ptd_verjir;

        return this;
    }
}
