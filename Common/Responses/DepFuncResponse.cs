using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class DepFuncResponse
{
    public int Id { get; set; }
    public int Dfc_dpt_identi { get; set; }
    public int Dfc_fnc_identi { get; set; }
    public int Dfc_usu_identi { get; set; }
    public String Dfc_usubdd { get; set; }
    public int Dfc_usucri { get; set; }
    public int Dfc_usualt { get; set; }
    public DateTime Dfc_datcri { get; set; }
    public DateTime Dfc_datalt { get; set; }
}
