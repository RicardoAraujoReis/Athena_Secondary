using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests.Searchs;

public class SearchPreAtendimentoPlantaoByParameters
{
    public string id { get; set; }
    public string titulo { get; set; }
    public string statusSelected { get; set; }
    public int linhaNegocioSelected { get; set; }
    public int clienteSelected { get; set; }
    public DateTime? dataInicioPreAtendimento { get; set; }
    public DateTime? dataFimPreAtendimento { get; set; }
    public string resumo { get; set; }
    public string tipoPreAtendimentoSelected { get; set; }
    public string criticidadeSelected { get; set; }
    public string analistaN1Selected { get; set; }
    public string jira { get; set; }
}
