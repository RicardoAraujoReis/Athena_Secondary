using Models.Interfaces;

namespace Athena.Models;

public class Funcao : BaseEntity<int>
{    
    public string Fnc_descri { get; set; }
    public string Fnc_ativo { get; set; }
    public string Fnc_usubdd { get; set; }
    public int Fnc_usucri { get; set; }
    public int? Fnc_usualt { get; set; }
    public DateTime Fnc_datcri { get; set; }
    public DateTime? Fnc_datalt { get; set; }
    public virtual List<DepFunc> DepFuncs { get; set; }

    public Funcao UpdateFuncao(
        int id,
        string fnc_descri,
        string fnc_ativo,
        string fnc_usubdd,
        int fnc_usucri,
        int fnc_usualt,
        DateTime fnc_datcri,
        DateTime fnc_datalt
    )
    {
        Id = id;
        Fnc_descri = fnc_descri;
        Fnc_ativo = fnc_ativo;
        Fnc_usubdd = fnc_usubdd;
        Fnc_usucri = fnc_usucri;
        Fnc_usualt = fnc_usualt;
        Fnc_datcri = fnc_datcri;
        Fnc_datalt = fnc_datalt;

        return this;
    }
}
