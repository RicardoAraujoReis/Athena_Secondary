using Models.Interfaces;

namespace Athena.Models;

public class AtendimentoPlantao : BaseEntity<int>
{    
    public int Atd_identi { get; set; }
    public int Atd_usu_identi { get; set; }        
    public int Atd_ptd_identi { get; set; }    
    public int Atd_cli_identi { get; set; }    
    public String Atd_tipatd { get; set; }
    public int Atd_cat_identi { get; set; }    
    public String Atd_resumo { get; set; }
    public String Atd_respn2 { get; set; }
    public String Atd_crijir { get; set; }
    public String Atd_issue { get; set; }
    public String Atd_critic { get; set; }
    public String Atd_resplt { get; set; }
    public String Atd_ren1hm { get; set; }
    public String Atd_resn1 { get; set; }
    public String Atd_evoln1 { get; set; }
    public String Atd_observ { get; set; }
    public String Atd_usubdd { get; set; }
    public DateTime Atd_datatd { get; set; }
    public String Atd_nomal2 { get; set; }
    public String Atd_status { get; set; }
    public int Atd_usucri { get; set; }
    public int Atd_usualt { get; set; }
    public DateTime Atd_datcri { get; set; }
    public DateTime Atd_datalt { get; set; }
    public virtual Usuario Usuario { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual PreAtendimentoPlantao PreAtendimentoPlantao { get; set; }
    public virtual CategoriaAtendimento CategoriaAtendimento { get; set; }

    public AtendimentoPlantao UpdateAtendimentoPlantao(
        int atd_identi,
        int atd_usu_identi,        
        int atd_cli_identi,
        String atd_tipatd,
        int atd_cat_identi,
        String atd_resumo,
        String atd_respn2,
        String atd_crijir,
        String atd_issue,
        String atd_critic,
        String atd_resplt,
        String atd_ren1hm,
        String atd_resn1,
        String atd_evoln1,
        String atd_observ,
        String atd_usubdd,
        DateTime atd_datatd,
        String atd_nomal2,
        String atd_status,
        int atd_usucri,
        int atd_usualt,
        DateTime atd_datcri,
        DateTime atd_datalt
    )
    {
        Atd_usu_identi = atd_usu_identi;
        Atd_cli_identi = atd_cli_identi;
        Atd_tipatd = atd_tipatd;
        Atd_cat_identi = atd_cat_identi;
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
        Atd_status = atd_status;
        Atd_usucri = atd_usucri;
        Atd_usualt = atd_usualt;
        Atd_datcri = atd_datcri;
        Atd_datalt = atd_datalt;

        return this;
    }

    /*public AtendimentoPlantao UpdateAtendimentoPlantao(AtendimentoPlantao atendimentoPlantao)
    {                
        return this;
    }*/
}
