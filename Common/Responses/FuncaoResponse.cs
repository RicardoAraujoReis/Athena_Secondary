using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class FuncaoResponse
{
    public int Id { get; set; }
    public String Fnc_descri { get; set; }
    public String Fnc_ativo { get; set; }
    public String Fnc_usubdd { get; set; }
    public int Fnc_usucri { get; set; }
    public int Fnc_usualt { get; set; }
    public DateTime Fnc_datcri { get; set; }
    public DateTime Fnc_datalt { get; set; }
}
