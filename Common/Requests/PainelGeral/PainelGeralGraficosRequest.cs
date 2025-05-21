using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests.PainelGeral;

public class PainelGeralGraficosRequest
{
    public string NomeCliente { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
}
