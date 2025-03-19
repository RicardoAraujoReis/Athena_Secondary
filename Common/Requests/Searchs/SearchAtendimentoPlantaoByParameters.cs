using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests.Searchs;

public class SearchAtendimentoPlantaoByParameters
{
    public string id { get; set; }
    public string titulo { get; set; }
    public string statusSelected { get; set; }
    public int linhaNegocioSelected { get; set; }
    public int clienteSelected { get; set; }
    public DateTime? dataInicioAtendimento { get; set; }
    public DateTime? dataFimAtendimento { get; set; }
    public string resumo { get; set; }
    public string tipoAtendimentoSelected { get; set; }
    public string criticidadeSelected { get; set; }
    public string analistaN1Selected { get; set; }
    public string jira { get; set; }
}
