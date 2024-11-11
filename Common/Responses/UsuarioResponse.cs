using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class UsuarioResponse
{
    public int Id { get; set; }
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
}
