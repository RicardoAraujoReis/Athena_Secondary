using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests.Searchs;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.AtendimentoPlantao;

public partial class ConsultaAtendimentoPlantao
{
    public SearchAtendimentoPlantaoByParameters SearchAtendimentoPlantaoByParameters { get; set; } = new();

    MudForm _form = default;

    public string id = null;
    public string titulo = null;
    public string statusSelected = null;
    public string linhaNegocioSelected = null;
    public string clienteSelected = null;
    public DateTime? dataInicioAtendimento;
    public DateTime? dataFimAtendimento;
    public string resumo = null;
    public string tipoAtendimentoSelected = null;
    public string criticidadeSelected = null;
    public string analistaN1Selected = null;
    public string jira = null;

    private List<LinhaNegocioResponse> _linhaNegocios = new List<LinhaNegocioResponse>();
    private List<ClienteResponse> _clientes = new List<ClienteResponse>();
    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();
    private List<string> nomeDadosListasCriticidade = null;
    private List<string> nomeDadosListasTipoAtendimento = null;
    private List<string> nomeDadosListasAnalistaN1 = null;
    private List<string> nomeDadosListasJiraRelacionado = null;
    private List<string> nomeDadosListasStatus = null;

    private List<AtendimentoPlantaoResponse> atendimentos = new List<AtendimentoPlantaoResponse> { };

    private string dataAlteracao = "---";
    private bool sucessoConsulta = false;

    protected override async Task OnInitializedAsync()
    {
        var requestClientes = await _clienteServices.GetClienteAllAsync();
        if (requestClientes.IsSuccessful)
        {
            _clientes = requestClientes.Data;
        }
        else
        {
            _snackbar.Add(requestClientes.Messages, Severity.Error);
        }

        var requestLinhaNegocio = await _linhaNegocioServices.GetLinhaNegocioAllAsync();
        if (requestLinhaNegocio.IsSuccessful)
        {
            _linhaNegocios = requestLinhaNegocio.Data;
        }
        else
        {
            _snackbar.Add(requestLinhaNegocio.Messages, Severity.Error);
        }

        var requestDadosListas = await _dadosListasServices.GetDadosListasAllAsync();
        if (requestDadosListas.IsSuccessful)
        {
            _dadosListas = requestDadosListas.Data;
        }
        else
        {
            _snackbar.Add(requestDadosListas.Messages, Severity.Error);
        }

        nomeDadosListasCriticidade = _dadosListas.Where(dados => dados.Dal_tid_descri == "CRITICIDADE").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasTipoAtendimento = _dadosListas.Where(dados => dados.Dal_tid_descri == "TIPO ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N1").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasJiraRelacionado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA RELACIONADO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasStatus = _dadosListas.Where(dados => dados.Dal_tid_descri == "STATUS ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
    }

    private async Task SubmitAsync()
    {
        if ((id == null || !id.Any()) && (titulo == null || !titulo.Any()) && (statusSelected == null || !statusSelected.Any()) &&
            (linhaNegocioSelected == null || !linhaNegocioSelected.Any()) && (clienteSelected == null || !clienteSelected.Any()) &&
            (dataInicioAtendimento == null) && (dataFimAtendimento == null) && (resumo == null || !resumo.Any()) &&
            (tipoAtendimentoSelected == null || !tipoAtendimentoSelected.Any()) && (analistaN1Selected == null || !analistaN1Selected.Any()) &&
            (jira == null || !jira.Any()))
        {
            _snackbar.Add("Falha ao validar o formulário, ao menos um filtro deve ser preenchido", Severity.Error);
        }
        else
        {
            await Consulta();
        }
    }

    public async Task Consulta()
    {
        var linhaNegocioId = _linhaNegocios.Where(linhaNegocio => linhaNegocio.Lhn_descri == linhaNegocioSelected).
            Select(linhaNegocio => linhaNegocio.Id).FirstOrDefault();
        var clienteId = _clientes.Where(cliente => cliente.Cli_descri == clienteSelected).Select(cliente => cliente.Id).FirstOrDefault();

        var filtros = new SearchAtendimentoPlantaoByParameters
        {
            id = id,
            titulo = titulo,
            statusSelected = statusSelected,
            linhaNegocioSelected = linhaNegocioId,
            clienteSelected = clienteId,
            dataInicioAtendimento = dataInicioAtendimento,
            dataFimAtendimento = dataFimAtendimento,
            resumo = resumo,
            tipoAtendimentoSelected = tipoAtendimentoSelected,
            criticidadeSelected = criticidadeSelected,
            analistaN1Selected = analistaN1Selected,
            jira = jira
        };

        var resultado = await _atendimentoPlantaoServices.GetAtendimentoPlantaoByParametersAsync(filtros);

        if (resultado.IsSuccessful)
        {
            atendimentos = resultado.Data;
            sucessoConsulta = true;
        }
        else
        {
            _snackbar.Add(resultado.Messages, Severity.Error);
        }
    }

    private async Task ViewAtendimentoPlantaoAsync(int idAtendimentoToView)
    {

    }
}
