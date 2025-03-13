using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class ViewPreAtendimentoPlantaoDialog
{
    [Parameter]
    public ViewPreAtendimentoPlantao ViewPreAtendimentoPlantao { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private CreateAtendimentoPlantao atendimentoPlantaoRequest = new();

    private ClienteResponse cliente = null;
    private string dadoListaJiraRelacionadoAtual = null;

    private string clienteDescricao = null;        

    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();

    private List<string> nomeDadosListasCriticidade = null;
    private string dadoListaCriticidadeSelected = null;

    private List<string> nomeDadosListasTipoAtendimento = null;
    private string dadoListaTipoAtendimentoSelected = null;

    private List<string> nomeDadosListasAnalistaN2 = null;
    private string dadoListaAnalistaN2Selected = null;

    private List<string> dadosListasJiraCriado = null;
    private string dadoListaJiraCriadoSelected = null;

    private string numeroIssueJira = null;

    private List<string> dadosListasResolvidoPlantao = null;
    private string resolvidoPlantaoSelected = null;

    private List<string> dadosListasResolveriaN1 = null;
    private string resolveriaN1Selected;

    private List<string> dadosListasResolveriaN1SeTeste = null;
    private string resolveriaN1SeTesteSelected = null;

    private List<string> dadosListasEvolucaoN1 = null;
    private string evolucaoN1Selected = null;

    private string respostaN2 = null;

    protected override async Task OnInitializedAsync()
    {
        var clienteAtualRequest = await _clienteServices.GetClienteByIdAsync(ViewPreAtendimentoPlantao.Ptd_cli_identi);

        if (clienteAtualRequest.IsSuccessful)
        {
            cliente = clienteAtualRequest.Data;
            clienteDescricao = cliente.Cli_descri;
        }
        else
        {
            _snackbar.Add(clienteAtualRequest.Messages, Severity.Error);
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

        var criticidadeAtual = ViewPreAtendimentoPlantao.Ptd_critic;

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

        if (ViewPreAtendimentoPlantao.Ptd_jirarl == "S")
        {
            dadoListaJiraRelacionadoAtual = "SIM";
        }
        else
        {
            dadoListaJiraRelacionadoAtual = "NAO";
        }

        nomeDadosListasCriticidade = _dadosListas.Where(dados => dados.Dal_tid_descri == "CRITICIDADE").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasTipoAtendimento = _dadosListas.Where(dados => dados.Dal_tid_descri == "TIPO ATENDIMENTO").Select(dados => dados.Dal_valor).ToList();
        nomeDadosListasAnalistaN2 = _dadosListas.Where(dados => dados.Dal_tid_descri == "ANALISTA N2").Select(dados => dados.Dal_valor).ToList();
        dadosListasJiraCriado = _dadosListas.Where(dados => dados.Dal_tid_descri == "JIRA CRIADO").Select(dados => dados.Dal_valor).ToList();
        dadosListasResolvidoPlantao = _dadosListas.Where(dados => dados.Dal_tid_descri == "RESOLVIDO NO PLANTAO").Select(dados => dados.Dal_valor).ToList();
        dadosListasResolveriaN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "RESOLVERIA N1").Select(dados => dados.Dal_valor).ToList();
        dadosListasResolveriaN1SeTeste = _dadosListas.Where(dados => dados.Dal_tid_descri == "RESOLVERIA N1 SE TESTE").Select(dados => dados.Dal_valor).ToList();
        dadosListasEvolucaoN1 = _dadosListas.Where(dados => dados.Dal_tid_descri == "EVOLUCAO N1").Select(dados => dados.Dal_valor).ToList();
    }

    private async Task GeraAtendimentoPlantao()
    {
        atendimentoPlantaoRequest.Atd_tipatd = dadoListaTipoAtendimentoSelected;
        
        if(resolvidoPlantaoSelected == "SIM")
        {
            atendimentoPlantaoRequest.Atd_respn2 = respostaN2;
        }
        else
        {
            atendimentoPlantaoRequest.Atd_respn2 = ViewPreAtendimentoPlantao.Ptd_reton2;
        }        

        if (dadoListaJiraCriadoSelected == "SIM")
        {
            atendimentoPlantaoRequest.Atd_crijir = "S";
        }
        else
        {
            atendimentoPlantaoRequest.Atd_crijir = "N";
        }

        atendimentoPlantaoRequest.Atd_issue = numeroIssueJira;

        if (dadoListaCriticidadeSelected == "TRIVIAL")
        {
            atendimentoPlantaoRequest.Atd_critic = "T";
        }
        else if (dadoListaCriticidadeSelected == "BAIXA")
        {
            atendimentoPlantaoRequest.Atd_critic = "B";
        }
        else if (dadoListaCriticidadeSelected == "MEDIA")
        {
            atendimentoPlantaoRequest.Atd_critic = "M";
        }
        else if (dadoListaCriticidadeSelected == "ALTA")
        {
            atendimentoPlantaoRequest.Atd_critic = "A";
        }
        else
        {
            atendimentoPlantaoRequest.Atd_critic = "C";
        }

        if (resolvidoPlantaoSelected == "SIM")
        {
            atendimentoPlantaoRequest.Atd_resplt = "S";
        }
        else
        {
            atendimentoPlantaoRequest.Atd_resplt = "N";
        }

        if (resolveriaN1SeTesteSelected == "SIM")
        {
            atendimentoPlantaoRequest.Atd_ren1hm = "S";
        }
        else
        {
            atendimentoPlantaoRequest.Atd_ren1hm = "N";
        }

        if (resolveriaN1Selected == "SIM")
        {
            atendimentoPlantaoRequest.Atd_resn1 = "S";
        }
        else
        {
            atendimentoPlantaoRequest.Atd_resn1 = "N";
        }

        atendimentoPlantaoRequest.Atd_evoln1 = evolucaoN1Selected;
        atendimentoPlantaoRequest.Atd_nomal2 = dadoListaAnalistaN2Selected;
        atendimentoPlantaoRequest.Atd_titulo = ViewPreAtendimentoPlantao.Ptd_titulo;
        atendimentoPlantaoRequest.Atd_resumo = ViewPreAtendimentoPlantao.Ptd_resumo;
        atendimentoPlantaoRequest.Atd_datatd = DateTime.Now;
        atendimentoPlantaoRequest.Atd_status = "ABERTO";
        atendimentoPlantaoRequest.Atd_usubdd = "ViewDialog";
        atendimentoPlantaoRequest.Atd_usucri = 1;
        atendimentoPlantaoRequest.Atd_datcri = DateTime.Now;
        atendimentoPlantaoRequest.Atd_linjir = ViewPreAtendimentoPlantao.Ptd_linjir;
        atendimentoPlantaoRequest.Atd_verjir = ViewPreAtendimentoPlantao.Ptd_verjir;

        var requestAtendimento = await _atendimentoPlantaoServices.CreateAtendimentoPlantaoAsync(atendimentoPlantaoRequest);
        if (requestAtendimento.IsSuccessful)
        {
            _snackbar.Add("Atendimento criado com sucesso", Severity.Success);
        }
        else
        {
            _snackbar.Add("Falha ao criar o Atendimento", Severity.Error);
        }

        MudDialog.Close();
    }

    private void Cancel() => MudDialog.Cancel();
}
