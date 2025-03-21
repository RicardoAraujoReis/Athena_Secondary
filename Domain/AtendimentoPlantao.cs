using Models;
using Models.Interfaces;

namespace Athena.Models;

public class AtendimentoPlantao : BaseEntity<int>
{    
    public int Atd_usu_identi { get; set; }        
    public int Atd_ptd_identi { get; set; }    
    public int Atd_cli_identi { get; set; }
    public string Atd_titulo { get; set; }
    public string Atd_tipatd { get; set; }    
    public string Atd_resumo { get; set; }
    public string Atd_respn2 { get; set; }
    public string Atd_crijir { get; set; }
    public string? Atd_issue { get; set; }
    public string Atd_critic { get; set; }
    public string Atd_resplt { get; set; }
    public string? Atd_ren1hm { get; set; }
    public string Atd_resn1 { get; set; }
    public string? Atd_evoln1 { get; set; }
    public string? Atd_observ { get; set; }
    public string Atd_usubdd { get; set; }
    public DateTime Atd_datatd { get; set; }
    public string Atd_nomal2 { get; set; }
    public string Atd_nomal1 { get; set; }
    public string Atd_status { get; set; }
    public string Atd_catnv1 { get; set; }
    public string Atd_catnv2 { get; set; }
    public string Atd_catnv3 { get; set; }
    public string? Atd_catnv4 { get; set; }
    public int Atd_usucri { get; set; }
    public int? Atd_usualt { get; set; }
    public DateTime Atd_datcri { get; set; }
    public DateTime? Atd_datalt { get; set; }
    public string? Atd_linjir { get; set; }
    public string? Atd_verjir { get; set; }
    public string Atd_jirarl { get; set; }
    public virtual PreAtendimentoPlantao PreAtendimentoPlantao { get; set; }    
    public virtual List<ComentariosAtendimentoPlantao>? Comentarios { get; set; }

    public AtendimentoPlantao UpdateAtendimentoPlantao(
        int id,
        int atd_usu_identi,        
        int atd_cli_identi,
        string atd_titulo,
        string atd_tipatd,        
        string atd_resumo,
        string atd_respn2,
        string atd_crijir,
        string atd_issue,
        string atd_critic,
        string atd_resplt,
        string atd_ren1hm,
        string atd_resn1,
        string atd_evoln1,
        string atd_observ,
        string atd_usubdd,
        DateTime atd_datatd,
        string atd_nomal2,
        string atd_nomal1,
        string atd_status,
        string atd_catnv1,
        string atd_catnv2,
        string atd_catnv3,
        string? atd_catnv4,
        int atd_usucri,
        int atd_usualt,
        DateTime atd_datcri,
        DateTime atd_datalt,
        string atd_linjir,
        string atd_verjir,
        string atd_jirarl
    )
    {
        Id = id;
        Atd_usu_identi = atd_usu_identi;
        Atd_cli_identi = atd_cli_identi;
        Atd_titulo = atd_titulo;
        Atd_tipatd = atd_tipatd;        
        Atd_resumo = atd_resumo;
        Atd_respn2 = atd_respn2;
        Atd_crijir = atd_crijir;
        Atd_issue = atd_issue;
        Atd_critic = atd_critic;
        Atd_resplt = atd_resplt;
        Atd_ren1hm = atd_ren1hm;
        Atd_resn1 = atd_resn1;
        Atd_evoln1 = atd_evoln1;
        Atd_observ = atd_observ;
        Atd_usubdd = atd_usubdd;
        Atd_datatd = atd_datatd;
        Atd_nomal2 = atd_nomal2;
        Atd_nomal1 = atd_nomal1;
        Atd_status = atd_status;
        Atd_catnv1 = atd_catnv1;
        Atd_catnv2 = atd_catnv2;
        Atd_catnv3 = atd_catnv3;
        Atd_catnv4 = atd_catnv4;
        Atd_usucri = atd_usucri;
        Atd_usualt = atd_usualt;
        Atd_datcri = atd_datcri;
        Atd_datalt = atd_datalt;
        Atd_linjir = atd_linjir;
        Atd_verjir = atd_verjir;
        Atd_jirarl = atd_jirarl;

        return this;
    }
}
