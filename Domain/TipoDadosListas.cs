using Models.Interfaces;

namespace Athena.Models;

public class TipoDadosListas : BaseEntity<int>
{    
    public string Tid_descri { get; set; }
    public string Tid_usubdd { get; set; }
    public DateTime Tid_datcri { get; set; }
    public DateTime? Tid_datalt { get; set; }
    public int Tid_usucri { get; set; }
    public int? Tid_usualt { get; set; }
    public virtual List<DadosListas> DadosListas { get; set; }

    public TipoDadosListas UpdateTipoDadosListas(
        int id,
        string tid_descri,
        string tid_usubdd,
        DateTime tid_datcri,
        DateTime tid_datalt,
        int tid_usucri,
        int tid_usualt
    )
    {
        Id = id;
        Tid_descri = tid_descri;
        Tid_usubdd = tid_usubdd;
        Tid_datcri = tid_datcri;
        Tid_datalt = tid_datalt;
        Tid_usucri = tid_usucri;
        Tid_usualt = tid_usualt;

        return this;
    }
}
