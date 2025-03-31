using Athena.Web.Pages.Shared;
using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class CreatePreAtendimentoPlantaoDialog
{
    [Parameter]
    public CreatePreAtendimentoPlantao CreatePreAtendimentoPlantaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private PreAtendimentoPlantaoValidator _validator = new();

    private DateTime? dataPreAtendimento;

    private List<LinhaNegocioResponse> _linhaNegocios = new List<LinhaNegocioResponse>();
    private int? LinhaNegocioSelected;

    private List<ClienteResponse> _clientes = new List<ClienteResponse>();
    private string clienteSelected = null;

    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();
    
    private List<string> nomeDadosListasCriticidade = null;
    private string dadoListaCriticidadeSelected = null;
    
    private List<string> nomeDadosListasTipoPreAtendimento = null;
    private string dadoListaTipoPreAtendimentoSelected = null;

    private List<string> nomeDadosListasAnalistaN1 = null;
    private string dadoListaAnalistaN1Selected = null;
  
    private List<string> nomeDadosListasJiraRelacionado = null;
    private string dadoListaJiraRelacionadoSelected = null;    

    protected override async Task OnInitializedAsync()
    {        
        dataPreAtendimento = DateTime.Today;

        var requestClientes = await _clienteServices.GetClienteAllAsync();
        if (requestClientes.IsSuccessful)
        {
            _clientes = requestClientes.Data;            
        }
        else
        {
            _snackbar.Add(requestClientes.Messages, Severity.Error);
            MudDialog.Close();
        }

        var requestLinhaNegocio = await _linhaNegocioServices.GetLinhaNegocioAllAsync();
        if (requestLinhaNegocio.IsSuccessful)
        {
            _linhaNegocios = requestLinhaNegocio.Data;
        }
        else
        {
            _snackbar.Add(requestLinhaNegocio.Messages, Severity.Error);
            MudDialog.Close();
        }

        var requestDadosListas = await _dadosListasServices.GetDadosListasAllAsync();
        if (requestDadosListas.IsSuccessful)
        {
            _dadosListas = requestDadosListas.Data;
        }
        else
        {
            _snackbar.Add(requestDadosListas.Messages, Severity.Error);
            MudDialog.Close();
        }

        nomeDadosListasCriticidade = _dadosListas.Where(dados=> dados.Dal_tid_descri == "CRITICIDADE").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasTipoPreAtendimento = _dadosListas.Where(dados => dados.Dal_tid_descri == "TIPO ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N1").Select(dados => dados.Dal_valor).ToList();        
        nomeDadosListasJiraRelacionado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA RELACIONADO").Select(dados => dados.Dal_valor).ToList();        
    }

    private async Task SubmitAsync()
    {
        await _form.Validate();

        if (CheckForm())
        {
            await SaveAsync();
        }
        else
        {
            _snackbar.Add("Falha ao validar o formulário", Severity.Error);
        }
    }

    private bool CheckForm()
    {
        if (_form.IsValid)
        {
            return true;
        }
        return false;
    }

    private async Task SaveAsync()
    {
        string message = $"Confirma a criação da Pre Atendimento?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.CreateConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateConfirmationDialog>("Criar novo Pre Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            CreatePreAtendimentoPlantaoRequest.Ptd_usucri = 1;
            CreatePreAtendimentoPlantaoRequest.Ptd_usualt = null;
            CreatePreAtendimentoPlantaoRequest.Ptd_datptd = dataPreAtendimento.Value;
            CreatePreAtendimentoPlantaoRequest.Ptd_datcri = DateTime.Now;
            CreatePreAtendimentoPlantaoRequest.Ptd_datalt = null;
            CreatePreAtendimentoPlantaoRequest.Ptd_usubdd = "PtdDialog";
            CreatePreAtendimentoPlantaoRequest.Ptd_usu_identi = 2; //DESENVOLVER RECURSO PARA RECUPERAR O USUÁRIO LOGADO
            CreatePreAtendimentoPlantaoRequest.Ptd_numatd = 1; //DESENVOLVER RECURSO PARA GRAVAR O NÚMERO DO ATENDIMENTO QUANDO ESTE FOR GERADO        
            CreatePreAtendimentoPlantaoRequest.Ptd_tipptd = dadoListaTipoPreAtendimentoSelected;
            CreatePreAtendimentoPlantaoRequest.Ptd_nomal1 = dadoListaAnalistaN1Selected;
            CreatePreAtendimentoPlantaoRequest.Ptd_status = "ABERTO";

            if (!string.IsNullOrWhiteSpace(clienteSelected))
            {
                var cliente = _clientes.Where(cliente => cliente.Cli_descri == clienteSelected).Select(cliente => cliente.Id);
                CreatePreAtendimentoPlantaoRequest.Ptd_cli_identi = cliente.FirstOrDefault();
            }

            if (!string.IsNullOrWhiteSpace(dadoListaCriticidadeSelected))
            {
                if (dadoListaCriticidadeSelected.Equals("TRIVIAL"))
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_critic = "T";
                }
                else if (dadoListaCriticidadeSelected.Equals("BAIXA"))
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_critic = "B";
                }
                else if (dadoListaCriticidadeSelected.Equals("MEDIA"))
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_critic = "M";
                }
                else if (dadoListaCriticidadeSelected.Equals("ALTA"))
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_critic = "A";
                }
                else
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_critic = "C";
                }
            }

            if (!string.IsNullOrWhiteSpace(dadoListaJiraRelacionadoSelected))
            {
                if (dadoListaJiraRelacionadoSelected.Equals("NAO"))
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_jirarl = "N";
                }
                else
                {
                    CreatePreAtendimentoPlantaoRequest.Ptd_jirarl = "S";
                }

            }

            var response = await _preAtendimentoPlantaoServices.CreatePreAtendimentoPlantaoAsync(CreatePreAtendimentoPlantaoRequest);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                MudDialog.Close();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private void Cancel() => MudDialog.Cancel();    
}
