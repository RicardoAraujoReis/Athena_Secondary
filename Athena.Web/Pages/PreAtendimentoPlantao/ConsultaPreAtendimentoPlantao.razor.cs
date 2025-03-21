using Athena.Web.Pages.Shared;
using Athena.Web.Services.ServicesImplementation;
using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests;
using Common.Requests.Searchs;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Runtime.CompilerServices;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class ConsultaPreAtendimentoPlantao
{
    //[Parameter]
    public SearchPreAtendimentoPlantaoByParameters SearchPreAtendimentoPlantaoByParameters { get; set; } = new();

    MudForm _form = default;

    private ConsultaPreAtendimentoPlantaoValidator _validator = new();

    public string id = null;
    public string titulo = null;
    public string statusSelected = null;
    public string linhaNegocioSelected = null;
    public string clienteSelected = null;
    public DateTime? dataInicioPreAtendimento;
    public DateTime? dataFimPreAtendimento;
    public string resumo = null;
    public string tipoPreAtendimentoSelected = null;
    public string criticidadeSelected = null;
    public string analistaN1Selected = null;
    public string jira = null;

    private List<LinhaNegocioResponse> _linhaNegocios = new List<LinhaNegocioResponse>();
    private List<ClienteResponse> _clientes = new List<ClienteResponse>();
    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();
    private List<string> nomeDadosListasCriticidade = null;
    private List<string> nomeDadosListasTipoPreAtendimento = null;
    private List<string> nomeDadosListasAnalistaN1 = null;
    private List<string> nomeDadosListasJiraRelacionado = null;
    private List<string> nomeDadosListasStatus = null;

    private List<PreAtendimentoPlantaoResponse> preAtendimentos = new List<PreAtendimentoPlantaoResponse> { };

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
        nomeDadosListasTipoPreAtendimento = _dadosListas.Where(dados => dados.Dal_tid_descri == "TIPO ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N1").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasJiraRelacionado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA RELACIONADO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasStatus = _dadosListas.Where(dados => dados.Dal_tid_descri == "STATUS ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
    }

    private async Task SubmitAsync()
    {        
        if ((id == null || !id.Any()) && (titulo == null || !titulo.Any()) && (statusSelected == null || !statusSelected.Any()) &&
            (linhaNegocioSelected == null || !linhaNegocioSelected.Any()) && (clienteSelected == null || !clienteSelected.Any()) && (dataInicioPreAtendimento == null) &&
            (dataFimPreAtendimento == null) && (resumo == null || !resumo.Any()) && (tipoPreAtendimentoSelected == null || !tipoPreAtendimentoSelected.Any()) &&
            (analistaN1Selected == null || !analistaN1Selected.Any()) && (jira == null || !jira.Any()))
        {
            _snackbar.Add("Falha ao validar o formulário, ao menos um filtro deve ser preenchido", Severity.Error);
        }
        else if (dataInicioPreAtendimento is null && dataFimPreAtendimento is not null)
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
        preAtendimentos = null;

        var linhaNegocioId = _linhaNegocios.Where(linhaNegocio => linhaNegocio.Lhn_descri == linhaNegocioSelected).Select(linhaNegocio => linhaNegocio.Id).FirstOrDefault();
        var clienteId = _clientes.Where(cliente => cliente.Cli_descri == clienteSelected).Select(cliente => cliente.Id).FirstOrDefault();

        var filtros = new SearchPreAtendimentoPlantaoByParameters
        {
            id = id,
            titulo = titulo,
            statusSelected = statusSelected,
            linhaNegocioSelected = linhaNegocioId,
            clienteSelected = clienteId,
            dataInicioPreAtendimento = dataInicioPreAtendimento,
            dataFimPreAtendimento = dataFimPreAtendimento,
            resumo = resumo,
            tipoPreAtendimentoSelected = tipoPreAtendimentoSelected,
            criticidadeSelected = criticidadeSelected,
            analistaN1Selected = analistaN1Selected,
            jira = jira
        };

        var resultado = await _preAtendimentoPlantaoServices.GetPreAtendimentoPlantaoByParametersAsync(filtros);

        if (resultado.IsSuccessful)
        {
            if(resultado.Data.Count == 0)
            {
                _snackbar.Add("Nenhum registro encontrado para os parâmetros enviados", Severity.Error);
                sucessoConsulta = false;
            }
            else
            {
                preAtendimentos = resultado.Data;
                sucessoConsulta = true;
            }            
        }
        else
        {
            _snackbar.Add(resultado.Messages, Severity.Error);
        }
    }

    private async Task UpdatePreAtendimentoPlantaoAsync(int preAtendimentoPlantaoId)
    {
        var parameters = new DialogParameters();

        var preAtendimentoToUpdate = preAtendimentos.FirstOrDefault(preAtendimento => preAtendimento.Id == preAtendimentoPlantaoId);

        parameters.Add(nameof(UpdatePreAtendimentoPlantaoDialog.UpdatePreAtendimentoPlantaoRequest), new UpdatePreAtendimentoPlantao
        {
            Id = preAtendimentoPlantaoId,
            Ptd_datptd = preAtendimentoToUpdate.Ptd_datptd,
            Ptd_usu_identi = preAtendimentoToUpdate.Ptd_usu_identi,
            Ptd_cli_identi = preAtendimentoToUpdate.Ptd_cli_identi,
            Ptd_tipptd = preAtendimentoToUpdate.Ptd_tipptd,
            Ptd_critic = preAtendimentoToUpdate.Ptd_critic,
            Ptd_titulo = preAtendimentoToUpdate.Ptd_titulo,
            Ptd_resumo = preAtendimentoToUpdate.Ptd_resumo,
            Ptd_numcha = preAtendimentoToUpdate.Ptd_numcha,
            Ptd_jirarl = preAtendimentoToUpdate.Ptd_jirarl,
            Ptd_numjir = preAtendimentoToUpdate.Ptd_numjir,
            Ptd_diagn1 = preAtendimentoToUpdate.Ptd_diagn1,
            Ptd_status = preAtendimentoToUpdate.Ptd_status,
            Ptd_reton2 = preAtendimentoToUpdate.Ptd_reton2,
            Ptd_observ = preAtendimentoToUpdate.Ptd_observ,
            Ptd_nomal1 = preAtendimentoToUpdate.Ptd_nomal1,
            Ptd_numatd = preAtendimentoToUpdate.Ptd_numatd,
            Ptd_usubdd = preAtendimentoToUpdate.Ptd_usubdd,
            Ptd_datcri = preAtendimentoToUpdate.Ptd_datcri,
            Ptd_datalt = preAtendimentoToUpdate.Ptd_datalt,
            Ptd_usucri = preAtendimentoToUpdate.Ptd_usucri,
            Ptd_usualt = preAtendimentoToUpdate.Ptd_usualt,
            Ptd_linjir = preAtendimentoToUpdate.Ptd_linjir,
            Ptd_verjir = preAtendimentoToUpdate.Ptd_verjir
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdatePreAtendimentoPlantaoDialog>("Editar Pré Atendimento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await Consulta();
        }
    }

    private async Task DeletePreAtendimentoPlantaoAsync(int idPtdToDConfirm)
    {
        string message = $"Confirma a deleção do Pré Atendimento {idPtdToDConfirm} ?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.DeleteConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar Pré Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _preAtendimentoPlantaoServices.DeletePreAtendimentoPlantaoAsync(idPtdToDConfirm);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await Consulta();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private async Task ViewPreAtendimentoPlantaoAsync(int idPreAtendimentoToView)
    {
        var preAtendimentoToView = preAtendimentos.FirstOrDefault(preAtendimento => preAtendimento.Id == idPreAtendimentoToView);

        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        parameters.Add(nameof(ViewPreAtendimentoPlantaoDialog.ViewPreAtendimentoPlantao), new ViewPreAtendimentoPlantao
        {
            Id = idPreAtendimentoToView,
            Ptd_datptd = preAtendimentoToView.Ptd_datptd,
            Ptd_usu_identi = preAtendimentoToView.Ptd_usu_identi,
            Ptd_cli_identi = preAtendimentoToView.Ptd_cli_identi,
            Ptd_tipptd = preAtendimentoToView.Ptd_tipptd,
            Ptd_critic = preAtendimentoToView.Ptd_critic,
            Ptd_titulo = preAtendimentoToView.Ptd_titulo,
            Ptd_resumo = preAtendimentoToView.Ptd_resumo,
            Ptd_numcha = preAtendimentoToView.Ptd_numcha,
            Ptd_jirarl = preAtendimentoToView.Ptd_jirarl,
            Ptd_numjir = preAtendimentoToView.Ptd_numjir,
            Ptd_diagn1 = preAtendimentoToView.Ptd_diagn1,
            Ptd_status = preAtendimentoToView.Ptd_status,
            Ptd_reton2 = preAtendimentoToView.Ptd_reton2,
            Ptd_observ = preAtendimentoToView.Ptd_observ,
            Ptd_nomal1 = preAtendimentoToView.Ptd_nomal1,
            Ptd_numatd = preAtendimentoToView.Ptd_numatd,
            Ptd_usubdd = preAtendimentoToView.Ptd_usubdd,
            Ptd_datcri = preAtendimentoToView.Ptd_datcri,
            Ptd_datalt = preAtendimentoToView.Ptd_datalt,
            Ptd_usucri = preAtendimentoToView.Ptd_usucri,
            Ptd_usualt = preAtendimentoToView.Ptd_usualt,
            Ptd_linjir = preAtendimentoToView.Ptd_linjir,
            Ptd_verjir = preAtendimentoToView.Ptd_verjir
        });

        var dialog = _dialogService.Show<ViewPreAtendimentoPlantaoDialog>("Visualizar Pré Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {            
            await Consulta();
        }
    }
}