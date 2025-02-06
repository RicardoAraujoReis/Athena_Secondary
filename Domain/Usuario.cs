using Models.Interfaces;

namespace Athena.Models;

public class Usuario : BaseEntity<int>
{   
    public string Usu_descri { get; set; }
    public string Usu_login { get; set; }    
    public string Usu_senha { get; set; }
    public string Usu_email { get; set; }
    public string Usu_ativo { get; set; }
    public string Usu_status { get; set; }
    public string Usu_master { get; set; }
    public string Usu_tipusu { get; set; }
    public string Usu_usubdd { get; set; }
    public int Usu_usucri { get; set; } 
    public int? Usu_usualt { get; set; }
    public DateTime Usu_datcri { get; set; }
    public DateTime? Usu_datalt { get; set; }    
    public virtual List<PreAtendimentoPlantao> PreAtendimentos { get; set; }
    public virtual List<AtendimentoPlantao> Atendimentos { get; set; }
    public virtual List<DepFunc> DepFuncs { get; set; }
    public virtual List<UsuLhn> UsuLhn { get; set; }

    public Usuario UpdateUsuario(
        int id,
        string usu_descri,
        string usu_login,
        string usu_senha,
        string usu_email,
        string usu_ativo,
        string usu_status,
        string usu_master,
        string usu_tipusu,
        string usu_usubdd,
        int usu_usucri,
        int usu_usualt,
        DateTime usu_datcri,
        DateTime usu_datalt
    )
    {
        Id = id;
        Usu_descri = usu_descri;
        Usu_login = usu_login;
        Usu_senha = usu_senha;
        Usu_email = usu_email;
        Usu_ativo = usu_ativo;
        Usu_status = usu_status;
        Usu_master = usu_master;
        Usu_tipusu = usu_tipusu;
        Usu_usubdd = usu_usubdd;
        Usu_usucri = usu_usucri;
        Usu_usualt = usu_usualt;
        Usu_datcri = usu_datcri;
        Usu_datalt = usu_datalt;

        return this;
    }
   
}
