using Models.Interfaces;

namespace Athena.Models;

public class UsuLhn : BaseEntity<int>
{    
    public int Uln_identi { get; set; }
    public int Uln_usu_identi { get; set; }    
    public int Uln_lhn_identi { get; set; }    
    public String Uln_usubdd { get; set; }
    public int Uln_usucri { get; set; }
    public int Uln_usualt { get; set; }
    public DateTime Uln_datcri { get; set; }
    public DateTime Uln_datalt { get; set; }
    public virtual LinhaNegocio LinhaNegocio { get; set; }
    public virtual Usuario Usuario { get; set; }

    public UsuLhn UpdateUsuLhn(
        int uln_identi,
        int uln_usu_identi,
        int uln_lhn_identi,
        String uln_usubdd,
        int uln_usucri,
        int uln_usualt,
        DateTime uln_datcri,
        DateTime uln_datalt
    )
    {
        Uln_usu_identi = uln_usu_identi;
        Uln_lhn_identi = uln_lhn_identi;
        Uln_usubdd = uln_usubdd;
        Uln_usucri = uln_usucri;
        Uln_usualt = uln_usualt;
        Uln_datcri = uln_datcri;
        Uln_datalt = uln_datalt;

        return this;
    }
}
