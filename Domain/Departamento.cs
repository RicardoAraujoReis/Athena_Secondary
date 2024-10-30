using Models.Interfaces;

namespace Athena.Models;

public class Departamento : BaseEntity<int>
{
    public int Dpt_identi { get; set; }
    public String Dpt_descri { get; set; }
    public String Dpt_ativo { get; set; }
    public String Dpt_usubdd { get; set; }
    public int Dpt_usucri { get; set; }
    public int Dpt_usualt { get; set; }
    public DateTime Dpt_datcri { get; set; }
    public DateTime Dpt_datalt { get; set; }
    public virtual List<DepFunc> DepFuncs { get; set; }

    public Departamento UpdateDepartamento(
        int dpt_identi,
        String dpt_descri,
        String dpt_ativo,
        String dpt_usubdd,
        int dpt_usucri,
        int dpt_usualt,
        DateTime dpt_datcri,
        DateTime dpt_datalt
    )
    {
        Dpt_descri = dpt_descri;
        Dpt_ativo = dpt_ativo;
        Dpt_usubdd = dpt_usubdd;
        Dpt_usucri = dpt_usucri;
        Dpt_usualt = dpt_usualt;
        Dpt_datcri = dpt_datcri;
        Dpt_datalt = dpt_datalt;

        return this;
    }
}