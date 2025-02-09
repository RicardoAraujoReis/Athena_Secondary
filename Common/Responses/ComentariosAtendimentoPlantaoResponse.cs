using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class ComentariosAtendimentoPlantaoResponse
{
    public int Id { get; set; }
    public string Cap_coment { get; set; }
    public int Cap_usucri { get; set; }
    public string Cap_usubdd { get; set; }
    public int? Cap_usualt { get; set; }
    public DateTime Cap_datcri { get; set; }
    public DateTime? Cap_datalt { get; set; }
}
