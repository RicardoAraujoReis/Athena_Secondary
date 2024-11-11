using Models.Interfaces;

namespace Athena.Models;

public class DepFunc : BaseEntity<int>
{      
    public int Dfc_dpt_identi { get; set; }       
    public int Dfc_fnc_identi { get; set; }
    public int Dfc_usu_identi { get; set; }
    public String Dfc_usubdd { get; set; }
    public int Dfc_usucri { get; set; }
    public int Dfc_usualt { get; set; }
    public DateTime Dfc_datcri { get; set; }
    public DateTime Dfc_datalt { get; set; }
    public virtual Departamento Departamento { get; set; }
    public virtual Funcao Funcao { get; set; }
    public virtual Usuario Usuario { get; set; }

    public DepFunc UpdateDepFunc(
        int id,
        int dfc_dpt_identi,
        int dfc_fnc_identi,
        int dfc_usu_identi,
        String dfc_usubdd,
        int dfc_usucri,
        int dfc_usualt,
        DateTime dfc_datcri,
        DateTime dfc_datalt
    )
    {
        Id = id;
        Dfc_dpt_identi = dfc_dpt_identi;
        Dfc_fnc_identi = dfc_fnc_identi;
        Dfc_usu_identi = dfc_usu_identi;
        Dfc_usubdd = dfc_usubdd;
        Dfc_usucri = dfc_usucri;
        Dfc_usualt = dfc_usualt;
        Dfc_datcri = dfc_datcri;
        Dfc_datalt = dfc_datalt;

        return this;
    }

}
