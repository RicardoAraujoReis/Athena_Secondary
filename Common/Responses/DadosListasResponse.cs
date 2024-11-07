using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class DadosListasResponse
{
    public int Id { get; set; }
    public int Dal_tid_identi { get; set; }
    public String Dal_valor { get; set; }
    public String Dal_usubdd { get; set; }
    public DateTime Dal_datcri { get; set; }
    public DateTime Dal_datalt { get; set; }
    public int Dal_usucri { get; set; }
    public int Dal_usualt { get; set; }
}
