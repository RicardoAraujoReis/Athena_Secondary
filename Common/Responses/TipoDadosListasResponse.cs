using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class TipoDadosListasResponse
{
    public int Id { get; set; }
    public String Tid_descri { get; set; }
    public String Tid_usubdd { get; set; }
    public DateTime Tid_datcri { get; set; }
    public DateTime Tid_datalt { get; set; }
    public int Tid_usucri { get; set; }
    public int Tid_usualt { get; set; }
}
