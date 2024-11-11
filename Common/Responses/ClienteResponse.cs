using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class ClienteResponse
{
    public int Id { get; set; }
    public String Cli_descri { get; set; }
    public String Cli_ativo { get; set; }
    public String Cli_usubdd { get; set; }
    public int Cli_usucri { get; set; }
    public int Cli_usualt { get; set; }
    public DateTime Cli_datcri { get; set; }
    public DateTime Cli_datalt { get; set; }
    public int Cli_lhn_identi { get; set; }
}
