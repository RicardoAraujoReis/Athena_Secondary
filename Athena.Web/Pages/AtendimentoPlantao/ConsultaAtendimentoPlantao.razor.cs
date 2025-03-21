using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests;
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
    public string analistaN2Selected = null;
    public string jira = null;

    private List<LinhaNegocioResponse> _linhaNegocios = new List<LinhaNegocioResponse>();
    private List<ClienteResponse> _clientes = new List<ClienteResponse>();
    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();
    private List<string> nomeDadosListasCriticidade = null;
    private List<string> nomeDadosListasTipoAtendimento = null;
    private List<string> nomeDadosListasAnalistaN1 = null;
    private List<string> nomeDadosListasAnalistaN2 = null;
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
        nomeDadosListasAnalistaN2 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N2").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasJiraRelacionado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA RELACIONADO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasStatus = _dadosListas.Where(dados => dados.Dal_tid_descri == "STATUS ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
    }

    private async Task SubmitAsync()
    {
        if ((id == null || !id.Any()) && (titulo == null || !titulo.Any()) && (statusSelected == null || !statusSelected.Any()) &&
            (linhaNegocioSelected == null || !linhaNegocioSelected.Any()) && (clienteSelected == null || !clienteSelected.Any()) &&
            (dataInicioAtendimento == null) && (dataFimAtendimento == null) && (resumo == null || !resumo.Any()) &&
            (tipoAtendimentoSelected == null || !tipoAtendimentoSelected.Any()) && (analistaN1Selected == null || !analistaN1Selected.Any()) &&
            (jira == null || !jira.Any()) && (criticidadeSelected == null || !criticidadeSelected.Any()) && (analistaN2Selected == null || !analistaN2Selected.Any()))
        {
            _snackbar.Add("Falha ao validar o formulário, ao menos um filtro deve ser preenchido", Severity.Error);
        }
        else if (dataInicioAtendimento is null && dataFimAtendimento is not null)
        {
            _snackbar.Add("Falha ao validar o formulário, preencha a Data Início", Severity.Error);
        }
        else
        {
            await Consulta();
        }
    }

    public async Task Consulta()
    {
        atendimentos = null;

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
            analistaN2Selected = analistaN2Selected,
            jira = jira
        };

        var resultado = await _atendimentoPlantaoServices.GetAtendimentoPlantaoByParametersAsync(filtros);

        if (resultado.IsSuccessful)
        {

            if (resultado.Data.Count == 0)
            {
                _snackbar.Add("Nenhum registro encontrado para os parâmetros enviados", Severity.Error);
                sucessoConsulta = false;
            }
            else
            {
                atendimentos = resultado.Data;
                sucessoConsulta = true;
            }
        }
        else
        {
            _snackbar.Add(resultado.Messages, Severity.Error);
        }
    }

    private async Task ViewAtendimentoPlantaoAsync(int idAtendimentoToView)
    {
        var atendimentoToView = atendimentos.FirstOrDefault(atendimento => atendimento.Id == idAtendimentoToView);

        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            BackdropClick = false
        };

        parameters.Add(nameof(ViewAtendimentoPlantaoDialog.ViewAtendimentoPlantao), new ViewAtendimentoPlantao
        {
            Id = atendimentoToView.Id,
            Atd_ptd_identi = atendimentoToView.Atd_ptd_identi,
            Atd_titulo = atendimentoToView.Atd_titulo,
            Atd_cli_identi = atendimentoToView.Atd_cli_identi,
            Atd_tipatd = atendimentoToView.Atd_tipatd,
            Atd_resumo = atendimentoToView.Atd_resumo,
            Atd_respn2 = atendimentoToView.Atd_respn2,
            Atd_crijir = atendimentoToView.Atd_crijir,
            Atd_issue = atendimentoToView.Atd_issue,
            Atd_critic = atendimentoToView.Atd_critic,
            Atd_resplt = atendimentoToView.Atd_resplt,
            Atd_ren1hm = atendimentoToView.Atd_ren1hm,
            Atd_resn1 = atendimentoToView.Atd_resn1,
            Atd_evoln1 = atendimentoToView.Atd_evoln1,
            Atd_jusevo = atendimentoToView.Atd_jusevo,
            Atd_usubdd = atendimentoToView.Atd_usubdd,
            Atd_datatd = atendimentoToView.Atd_datatd,
            Atd_nomal2 = atendimentoToView.Atd_nomal2,
            Atd_nomal1 = atendimentoToView.Atd_nomal1,
            Atd_status = atendimentoToView.Atd_status,
            Atd_catnv1 = atendimentoToView.Atd_catnv1,
            Atd_catnv2 = atendimentoToView.Atd_catnv2,
            Atd_catnv3 = atendimentoToView.Atd_catnv3,
            Atd_catnv4 = atendimentoToView.Atd_catnv4,
            Atd_usucri = atendimentoToView.Atd_usucri,
            Atd_usualt = atendimentoToView.Atd_usualt,
            Atd_datcri = atendimentoToView.Atd_datcri,
            Atd_datalt = atendimentoToView.Atd_datalt,
            Atd_linjir = atendimentoToView.Atd_linjir,
            Atd_verjir = atendimentoToView.Atd_verjir,
            Atd_jirarl = atendimentoToView.Atd_jirarl
        });

        var dialog = _dialogService.Show<ViewAtendimentoPlantaoDialog>("Visualizar Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await Consulta();
        }
    }
}
