using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class DepartamentoResponse
{
    public int Id { get; set; }
    public string Dpt_descri { get; set; }
    public string Dpt_ativo { get; set; }
    public string Dpt_usubdd { get; set; }
    public int Dpt_usucri { get; set; }
    public int Dpt_usualt { get; set; }
    public DateTime Dpt_datcri { get; set; }
    public DateTime Dpt_datalt { get; set; }
}
