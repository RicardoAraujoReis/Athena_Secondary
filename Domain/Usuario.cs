using Models.Interfaces;

namespace Athena.Models;

public class Usuario : BaseEntity<int>
{
    public int Usu_identi { get; set; }
    public String Usu_descri { get; set; }
    public String Usu_login { get; set; }    
    public String Usu_senha { get; set; }
    public String Usu_email { get; set; }
    public String Usu_ativo { get; set; }
    public String Usu_status { get; set; }
    public String Usu_master { get; set; }
    public String Usu_tipusu { get; set; }
    public String Usu_usubdd { get; set; }
    public int Usu_usucri { get; set; } 
    public int Usu_usualt { get; set; }
    public DateTime Usu_datcri { get; set; }
    public DateTime Usu_datalt { get; set; }    
    public virtual List<PreAtendimentoPlantao> PreAtendimentos { get; set; }
    public virtual List<AtendimentoPlantao> Atendimentos { get; set; }
    public virtual List<DepFunc> DepFuncs { get; set; }
    public virtual List<UsuLhn> UsuLhn { get; set; }

    public Usuario UpdateUsuario(
        int usu_identi,
        String usu_descri,
        String usu_login,
        String usu_senha,
        String usu_email,
        String usu_ativo,
        String usu_status,
        String usu_master,
        String usu_tipusu,
        String usu_usubdd,
        int usu_usucri,
        int usu_usualt,
        DateTime usu_datcri,
        DateTime usu_datalt
    )
    {
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
