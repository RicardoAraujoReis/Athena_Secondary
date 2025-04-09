using Athena.Web.Pages.Shared;
using Athena.Web.Validators.AtendimentoPlantaoValidators;
using Athena.Web.Validators.ClienteValidators;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.AtendimentoPlantao;

public partial class UpdateAtendimentoPlantaoDialog
{
    [Parameter]
    public UpdateAtendimentoPlantao UpdateAtendimentoPlantaoRequest { get; set; } = new();

    private UpdatePreAtendimentoPlantao updatePreAtendimentoPlantao { get; set; } = new();
    private PreAtendimentoPlantaoResponse preAtendimentoPlantao { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateAtendimentoPlantaoValidator _validator = new();

    private List<ClienteResponse> _clientes = new List<ClienteResponse>();
    private string clienteSelected = null;

    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();

    private List<string> nomeDadosListasTipoPreAtendimento = null;
    private string dadoListaTipoPreAtendimentoSelected = null;

    private List<string> nomeDadosListasCriticidade = null;
    private string dadoListaCriticidadeSelected = null;    

    private List<string> nomeDadosListasAnalistaN1 = null;
    private string dadoListaAnalistaN1Selected = null;

    private List<string> nomeDadosListasAnalistaN2 = null;
    private string dadoListaAnalistaN2Selected = null;

    private List<string> nomeDadosListasJiraRelacionado = null;
    private string dadoListaJiraRelacionadoSelected = null;

    private List<string> nomeDadosListasStatus = null;
    private string dadoListaStatusSelected = null;

    private List<string> dadosListasResolvidoPlantao = null;
    private string resolvidoPlantaoSelected = null;

    private List<string> dadosListasResolveriaN1 = null;
    private string resolveriaN1Selected;

    private List<string> dadosListasResolveriaN1SeTeste = null;
    private string resolveriaN1SeTesteSelected = null;

    private List<string> dadosListasEvolucaoN1 = null;
    private string evolucaoN1Selected = null;
    private string justificativaEvolucao = null;

    private List<string> dadosListasJiraCriado = null;
    private string dadoListaJiraCriadoSelected = null;

    private string categoriaAtendimentoNivel1Selected = null;
    private string categoriaAtendimentoNivel2Selected = null;
    private string categoriaAtendimentoNivel3Selected = null;
    private string categoriaAtendimentoNivel4Selected = null;

    private List<LinhaNegocioResponse> _linhaNegocios = new List<LinhaNegocioResponse>();
    private int? linhaNegocioId;
    private string linhaNegocio = null;

    private DateTime? dataAtendimento;

    protected override async Task OnInitializedAsync()
    {
        dataAtendimento = UpdateAtendimentoPlantaoRequest.Atd_datatd;

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

        var clienteAtual = _clientes.Where(cliente => cliente.Id == UpdateAtendimentoPlantaoRequest.Atd_cli_identi).FirstOrDefault();
        clienteSelected = clienteAtual.Cli_descri;

        linhaNegocioId = _linhaNegocios.Where(linhaNegocio => linhaNegocio.Id == clienteAtual.Cli_lhn_identi)
            .Select(linhaNegocio => linhaNegocio.Id).FirstOrDefault();

        linhaNegocio = _linhaNegocios.Where(linhaNegocio => linhaNegocio.Id == clienteAtual.Cli_lhn_identi)
            .Select(linhaNegocio => linhaNegocio.Lhn_descri).FirstOrDefault();

        var criticidadeAtual = UpdateAtendimentoPlantaoRequest.Atd_critic;

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

        if(UpdateAtendimentoPlantaoRequest.Atd_ren1hm == "S")
        {
            resolveriaN1SeTesteSelected = "SIM";
        }
        else
        {
            resolveriaN1SeTesteSelected = "NAO";
        }

        if (UpdateAtendimentoPlantaoRequest.Atd_resn1 == "S")
        {
            resolveriaN1Selected = "SIM";
        }
        else
        {
            resolveriaN1Selected = "NAO";
        }

        if (UpdateAtendimentoPlantaoRequest.Atd_resplt == "S")
        {
            resolvidoPlantaoSelected = "SIM";
        }
        else
        {
            resolvidoPlantaoSelected = "NAO";
        }

        if (UpdateAtendimentoPlantaoRequest.Atd_jirarl == "S")
        {
            dadoListaJiraRelacionadoSelected = "SIM";
        }
        else
        {
            dadoListaJiraRelacionadoSelected = "NAO";
        }

        if(UpdateAtendimentoPlantaoRequest.Atd_crijir == "S")
        {
            dadoListaJiraCriadoSelected = "SIM";
        }
        else
        {
            dadoListaJiraCriadoSelected = "NAO";
        }

        nomeDadosListasCriticidade = _dadosListas.Where(dados => dados.Dal_tid_descri == "CRITICIDADE").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasTipoPreAtendimento = _dadosListas.Where(dados => dados.Dal_tid_descri == "TIPO ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N1").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN2 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N2").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasJiraRelacionado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA RELACIONADO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasStatus = _dadosListas.Where(dados => dados.Dal_tid_descri == "STATUS ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        dadosListasResolvidoPlantao = _dadosListas.Where(dados => dados.Dal_tid_descri == "RESOLVIDO NO PLANTAO").Select(dados => dados.Dal_valor).ToList();
        dadosListasResolveriaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "RESOLVERIA N1").Select(dados => dados.Dal_valor).ToList();
        dadosListasResolveriaN1SeTeste = _dadosListas.Where(dados => dados.Dal_tid_descri == "RESOLVERIA N1 SE TESTE").Select(dados => dados.Dal_valor).ToList();
        dadosListasEvolucaoN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "EVOLUCAO N1").Select(dados => dados.Dal_valor).ToList();
        dadosListasJiraCriado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA CRIADO").Select(dados => dados.Dal_valor).ToList();
        dadoListaTipoPreAtendimentoSelected = UpdateAtendimentoPlantaoRequest.Atd_tipatd;
        dadoListaAnalistaN1Selected = UpdateAtendimentoPlantaoRequest.Atd_nomal1;
        dadoListaAnalistaN2Selected = UpdateAtendimentoPlantaoRequest.Atd_nomal2;
        dadoListaStatusSelected = UpdateAtendimentoPlantaoRequest.Atd_status;
        evolucaoN1Selected = UpdateAtendimentoPlantaoRequest.Atd_evoln1;
        categoriaAtendimentoNivel1Selected = UpdateAtendimentoPlantaoRequest.Atd_catnv1;
        categoriaAtendimentoNivel2Selected = UpdateAtendimentoPlantaoRequest.Atd_catnv2;
        categoriaAtendimentoNivel3Selected = UpdateAtendimentoPlantaoRequest.Atd_catnv3;
        categoriaAtendimentoNivel4Selected = UpdateAtendimentoPlantaoRequest.Atd_catnv4;
    }

    private async Task SubmitAsync()
    {        
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
        _form.Validate();

        if (_form.IsValid)
        {
            return true;
        }
        return false;
    }

    private async Task SaveAsync()
    {
        string message = $"Confirma a atualização do Atendimento?";

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

        var dialog = _dialogService.Show<UpdateConfirmationDialog>("Atualizar o Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            UpdateAtendimentoPlantaoRequest.Atd_tipatd = dadoListaTipoPreAtendimentoSelected;
            UpdateAtendimentoPlantaoRequest.Atd_status = dadoListaStatusSelected;
            UpdateAtendimentoPlantaoRequest.Atd_catnv1 = categoriaAtendimentoNivel1Selected;
            UpdateAtendimentoPlantaoRequest.Atd_catnv2 = categoriaAtendimentoNivel2Selected;
            UpdateAtendimentoPlantaoRequest.Atd_catnv3 = categoriaAtendimentoNivel3Selected;
            UpdateAtendimentoPlantaoRequest.Atd_catnv4 = categoriaAtendimentoNivel4Selected;
            UpdateAtendimentoPlantaoRequest.Atd_critic = dadoListaCriticidadeSelected;
            UpdateAtendimentoPlantaoRequest.Atd_evoln1 = evolucaoN1Selected;
            UpdateAtendimentoPlantaoRequest.Atd_nomal2 = dadoListaAnalistaN2Selected;
            UpdateAtendimentoPlantaoRequest.Atd_nomal1 = dadoListaAnalistaN1Selected;
            UpdateAtendimentoPlantaoRequest.Atd_usualt = 2;
            UpdateAtendimentoPlantaoRequest.Atd_datalt = DateTime.Now;

            if (dadoListaJiraCriadoSelected == "SIM")
            {
                UpdateAtendimentoPlantaoRequest.Atd_crijir = "S";
            }
            else
            {
                UpdateAtendimentoPlantaoRequest.Atd_crijir = "N";
            }

            if (resolvidoPlantaoSelected == "SIM")
            {
                UpdateAtendimentoPlantaoRequest.Atd_resplt = "S";
            }
            else
            {
                UpdateAtendimentoPlantaoRequest.Atd_resplt = "N";
            }

            if (resolveriaN1SeTesteSelected == "SIM")
            {
                UpdateAtendimentoPlantaoRequest.Atd_ren1hm = "S";
            }
            else
            {
                UpdateAtendimentoPlantaoRequest.Atd_ren1hm = "N";
            }

            if (resolveriaN1Selected == "SIM")
            {
                UpdateAtendimentoPlantaoRequest.Atd_resn1 = "S";
            }
            else
            {
                UpdateAtendimentoPlantaoRequest.Atd_resn1 = "N";
            }

            if (dadoListaCriticidadeSelected == "TRIVIAL")
            {
                UpdateAtendimentoPlantaoRequest.Atd_critic = "T";
            }
            else if (dadoListaCriticidadeSelected == "BAIXA")
            {
                UpdateAtendimentoPlantaoRequest.Atd_critic = "B";
            }
            else if (dadoListaCriticidadeSelected == "MEDIA")
            {
                UpdateAtendimentoPlantaoRequest.Atd_critic = "M";
            }
            else if (dadoListaCriticidadeSelected == "ALTA")
            {
                UpdateAtendimentoPlantaoRequest.Atd_critic = "A";
            }
            else
            {
                UpdateAtendimentoPlantaoRequest.Atd_critic = "C";
            }

            var request = await _atendimentoPlantaoServices.UpdateAtendimentoPlantaoAsync(UpdateAtendimentoPlantaoRequest);
            if (request.IsSuccessful)
            {
                if(dadoListaStatusSelected == "FINALIZADO")
                {
                    AtualizaPreAtendimento();
                    _snackbar.Add("Atendimento finalizado com sucesso", Severity.Success);
                    _snackbar.Add("Pré Atendimento finalizado com sucesso", Severity.Success);
                }
                else if(dadoListaStatusSelected != "ABERTO" && dadoListaStatusSelected != "FINALIZADO")
                {
                    AtualizaPreAtendimento();
                }
                else
                {
                    _snackbar.Add("Atendimento atualizado com sucesso", Severity.Success);
                }                                
            }
            else
            {
                _snackbar.Add("Falha ao atualizar o Atendimento", Severity.Error);
            }
        }

        MudDialog.Close();            
    }

    private async Task AtualizaPreAtendimento()
    {
        var preAtendimentoPlantaoToFind = await _preAtendimentoPlantaoServices.GetPreAtendimentoPlantaoByIdAsync(UpdateAtendimentoPlantaoRequest.Atd_ptd_identi);

        if (preAtendimentoPlantaoToFind.IsSuccessful)
        {
            preAtendimentoPlantao = preAtendimentoPlantaoToFind.Data;
        }

        updatePreAtendimentoPlantao = new UpdatePreAtendimentoPlantao
        {
            Id = preAtendimentoPlantao.Id,
            Ptd_cli_identi = preAtendimentoPlantao.Ptd_cli_identi,
            Ptd_usu_identi = preAtendimentoPlantao.Ptd_usu_identi,
            Ptd_titulo = preAtendimentoPlantao.Ptd_titulo,
            Ptd_datptd = preAtendimentoPlantao.Ptd_datptd,
            Ptd_tipptd = preAtendimentoPlantao.Ptd_tipptd,
            Ptd_critic = preAtendimentoPlantao.Ptd_critic,
            Ptd_resumo = preAtendimentoPlantao.Ptd_resumo,
            Ptd_numcha = preAtendimentoPlantao.Ptd_numcha,
            Ptd_jirarl = preAtendimentoPlantao.Ptd_jirarl,
            Ptd_numjir = preAtendimentoPlantao.Ptd_numjir,
            Ptd_diagn1 = preAtendimentoPlantao.Ptd_diagn1,
            Ptd_reton2 = preAtendimentoPlantao.Ptd_reton2,
            Ptd_observ = preAtendimentoPlantao.Ptd_observ,
            Ptd_nomal1 = preAtendimentoPlantao.Ptd_nomal1,
            Ptd_numatd = preAtendimentoPlantao.Ptd_numatd,
            Ptd_usucri = preAtendimentoPlantao.Ptd_usucri,
            Ptd_usualt = preAtendimentoPlantao.Ptd_usualt,
            Ptd_datcri = preAtendimentoPlantao.Ptd_datcri,
            Ptd_datalt = preAtendimentoPlantao.Ptd_datalt,
            Ptd_usubdd = preAtendimentoPlantao.Ptd_usubdd,
            Ptd_linjir = preAtendimentoPlantao.Ptd_linjir,
            Ptd_verjir = preAtendimentoPlantao.Ptd_verjir,
            Ptd_status = UpdateAtendimentoPlantaoRequest.Atd_status
        };

        var updatePreAtendimentoRequest = await _preAtendimentoPlantaoServices.UpdatePreAtendimentoPlantaoAsync(updatePreAtendimentoPlantao);
        if (updatePreAtendimentoRequest.IsSuccessful)
        {
            _snackbar.Add("Status do Pré Atendimento atualizado com sucesso", Severity.Success);
        }
        else
        {
            _snackbar.Add("Falha ao atualizar o status do Pré Atendimento", Severity.Error);
        }
    }

    private void Cancel() => MudDialog.Cancel();
}
