using Athena.Web.Pages.Shared;
using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class UpdatePreAtendimentoPlantaoDialog
{
    [Parameter]
    public UpdatePreAtendimentoPlantao UpdatePreAtendimentoPlantaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdatePreAtendimentoPlantaoValidator _validator = new();

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

    private List<string> nomeDadosListasStatus = null;
    private string dadoListaStatusSelected = null;

    private DateTime? dataPreAtendimento;

    protected override async Task OnInitializedAsync()
    {
        dataPreAtendimento = UpdatePreAtendimentoPlantaoRequest.Ptd_datptd;

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

        var clienteAtual = _clientes.Where(cliente => cliente.Id == UpdatePreAtendimentoPlantaoRequest.Ptd_cli_identi).FirstOrDefault();
        clienteSelected = clienteAtual.Cli_descri;

        LinhaNegocioSelected = _linhaNegocios.Where(linhaNegocio => linhaNegocio.Id == clienteAtual.Cli_lhn_identi)
            .Select(linhaNegocio => linhaNegocio.Id).FirstOrDefault();

        var criticidadeAtual = UpdatePreAtendimentoPlantaoRequest.Ptd_critic;

        if (criticidadeAtual is not null)
        {
            if (criticidadeAtual.Equals("T"))
            {
                dadoListaCriticidadeSelected = "TRIVIAL";
            }
            else if (criticidadeAtual.Equals("B"))
            {
                dadoListaCriticidadeSelected = "BAIXA";
            }
            else if (criticidadeAtual.Equals("M"))
            {
                dadoListaCriticidadeSelected = "MEDIA";
            }
            else if (criticidadeAtual.Equals("A"))
            {
                dadoListaCriticidadeSelected = "ALTA";
            }
            else
            {
                dadoListaCriticidadeSelected = "CRITICA";
            }
        }

        dadoListaTipoPreAtendimentoSelected = UpdatePreAtendimentoPlantaoRequest.Ptd_tipptd;
        dadoListaAnalistaN1Selected = UpdatePreAtendimentoPlantaoRequest.Ptd_nomal1;
        dadoListaStatusSelected = UpdatePreAtendimentoPlantaoRequest.Ptd_status;

        if(UpdatePreAtendimentoPlantaoRequest.Ptd_jirarl == "S")
        {
            dadoListaJiraRelacionadoSelected = "SIM";
        }
        else
        {
            dadoListaJiraRelacionadoSelected = "NAO";
        }        

        nomeDadosListasCriticidade = _dadosListas.Where(dados => dados.Dal_tid_descri == "CRITICIDADE").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasTipoPreAtendimento = _dadosListas.Where(dados => dados.Dal_tid_descri == "TIPO ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N1").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasJiraRelacionado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA RELACIONADO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasStatus = _dadosListas.Where(dados => dados.Dal_tid_descri == "STATUS ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
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
        string message = $"Confirma a atualiação do Pre Atendimento?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.UpdateConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateConfirmationDialog>("Atualizar o Pre Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            UpdatePreAtendimentoPlantaoRequest.Ptd_usucri = UpdatePreAtendimentoPlantaoRequest.Ptd_usucri;
            UpdatePreAtendimentoPlantaoRequest.Ptd_usualt = 1;
            UpdatePreAtendimentoPlantaoRequest.Ptd_datptd = dataPreAtendimento.Value;
            UpdatePreAtendimentoPlantaoRequest.Ptd_datcri = UpdatePreAtendimentoPlantaoRequest.Ptd_datcri;
            UpdatePreAtendimentoPlantaoRequest.Ptd_datalt = DateTime.Now;
            UpdatePreAtendimentoPlantaoRequest.Ptd_usubdd = "PtdDialog";
            UpdatePreAtendimentoPlantaoRequest.Ptd_usu_identi = 2; //DESENVOLVER RECURSO PARA RECUPERAR O USUÁRIO LOGADO
            UpdatePreAtendimentoPlantaoRequest.Ptd_numatd = 1; //DESENVOLVER RECURSO PARA GRAVAR O NÚMERO DO ATENDIMENTO QUANDO ESTE FOR GERADO        
            UpdatePreAtendimentoPlantaoRequest.Ptd_tipptd = dadoListaTipoPreAtendimentoSelected;
            UpdatePreAtendimentoPlantaoRequest.Ptd_nomal1 = dadoListaAnalistaN1Selected;
            UpdatePreAtendimentoPlantaoRequest.Ptd_status = dadoListaStatusSelected;

            if (!string.IsNullOrWhiteSpace(clienteSelected))
            {
                var cliente = _clientes.Where(cliente => cliente.Cli_descri == clienteSelected).Select(cliente => cliente.Id);
                UpdatePreAtendimentoPlantaoRequest.Ptd_cli_identi = cliente.FirstOrDefault();
            }

            if (!string.IsNullOrWhiteSpace(dadoListaCriticidadeSelected))
            {
                if (dadoListaCriticidadeSelected.Equals("TRIVIAL"))
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_critic = "T";
                }
                else if (dadoListaCriticidadeSelected.Equals("BAIXA"))
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_critic = "B";
                }
                else if (dadoListaCriticidadeSelected.Equals("MEDIA"))
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_critic = "M";
                }
                else if (dadoListaCriticidadeSelected.Equals("ALTA"))
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_critic = "A";
                }
                else
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_critic = "C";
                }
            }

            if (!string.IsNullOrWhiteSpace(dadoListaJiraRelacionadoSelected))
            {
                if (dadoListaJiraRelacionadoSelected.Equals("NAO"))
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_jirarl = "N";
                }
                else
                {
                    UpdatePreAtendimentoPlantaoRequest.Ptd_jirarl = "S";
                }
            }

            var response = await _preAtendimentoPlantaoServices.UpdatePreAtendimentoPlantaoAsync(UpdatePreAtendimentoPlantaoRequest);
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
