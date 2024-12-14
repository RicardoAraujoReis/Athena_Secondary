using Models.Interfaces;

namespace Athena.Models;

public class LinhaNegocio : BaseEntity<int>
{        
    public String Lhn_descri { get; set; }    
    public String Lhn_ativo { get; set; }    
    public String Lhn_usubdd { get; set; }    
    public int Lhn_usucri { get; set; }
    public int? Lhn_usualt { get; set; }    
    public DateTime Lhn_datcri { get; set; }
    public DateTime? Lhn_datalt { get; set; }    
    public virtual List<Cliente> Clientes { get; set; }   
    public virtual List<UsuLhn> UsuLhn { get; set; }

    public LinhaNegocio UpdateLinhaNegocio(
        int id,
        String lhn_descri,
        String lhn_ativo,
        String lhn_usubdd,
        int lhn_usucri,
        int lhn_usualt,
        DateTime lhn_datcri,
        DateTime lhn_datalt
    )
    {
        Id = id;
        Lhn_descri = lhn_descri;
        Lhn_ativo = lhn_ativo;
        Lhn_usubdd = lhn_usubdd;
        Lhn_usucri = lhn_usucri;
        Lhn_usualt = lhn_usualt;
        Lhn_datcri = lhn_datcri;
        Lhn_datalt = lhn_datalt;

        return this;
    }
}
