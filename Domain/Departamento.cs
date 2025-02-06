using Models.Interfaces;

namespace Athena.Models;

public class Departamento : BaseEntity<int>
{   
    public string Dpt_descri { get; set; }
    public string Dpt_ativo { get; set; }
    public string Dpt_usubdd { get; set; }
    public int Dpt_usucri { get; set; }
    public int? Dpt_usualt { get; set; }
    public DateTime Dpt_datcri { get; set; }
    public DateTime? Dpt_datalt { get; set; }
    public virtual List<DepFunc> DepFuncs { get; set; }

    public Departamento UpdateDepartamento(
        int id,
        string dpt_descri,
        string dpt_ativo,
        string dpt_usubdd,
        int dpt_usucri,
        int dpt_usualt,
        DateTime dpt_datcri,
        DateTime dpt_datalt
    )
    {
        Id = id;
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