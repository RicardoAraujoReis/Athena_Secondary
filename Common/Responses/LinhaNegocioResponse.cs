using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class LinhaNegocioResponse
{
    public int Lhn_identi { get; set; }
    public String Lhn_descri { get; set; }
    public String Lhn_ativo { get; set; }
    public String Lhn_usubdd { get; set; }
    public int Lhn_usucri { get; set; }
    public int Lhn_usualt { get; set; }
    public DateTime Lhn_datcri { get; set; }
    public DateTime Lhn_datalt { get; set; }
}
