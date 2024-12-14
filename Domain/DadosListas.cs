using Models.Interfaces;

namespace Athena.Models;

public class DadosListas : BaseEntity<int>
{    
    public int Dal_tid_identi { get; set; }    
    public String Dal_valor { get; set; }
    public String Dal_usubdd { get; set; }
    public DateTime Dal_datcri { get; set; }
    public DateTime? Dal_datalt { get; set; }
    public int Dal_usucri { get; set; }
    public int? Dal_usualt { get; set; }
    public virtual TipoDadosListas TipoDadosListas { get; set; }

    public DadosListas UpdateDadosListas
    (
        int id,
        int dal_tid_identi,
        String dal_valor,
        String dal_usubdd,
        DateTime dal_datcri,
        DateTime dal_datalt,
        int dal_usucri,
        int dal_usualt
    )
    {
        Id = id;
        Dal_tid_identi = dal_tid_identi;
        Dal_valor = dal_valor;
        Dal_usubdd = dal_usubdd;
        Dal_datcri = dal_datcri;
        Dal_datalt = dal_datalt;
        Dal_usucri = dal_usucri;
        Dal_usualt = dal_usualt;

        return this;
    }
}
