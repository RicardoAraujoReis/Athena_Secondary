using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class ViewPreAtendimentoPlantaoDialog
{
    [Parameter]
    public ViewPreAtendimentoPlantao ViewPreAtendimentoPlantao { get; set; } = new();

    private UpdatePreAtendimentoPlantao updatePreAtendimentoPlantao { get; set; } = new();

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
    private string justificativaEvolucao = null;

    private string respostaN2 = null;

    private string categoriaAtendimentoNivel1Selected = null;
    private string categoriaAtendimentoNivel2Selected = null;
    private string categoriaAtendimentoNivel3Selected = null;
    private string categoriaAtendimentoNivel4Selected = null;

    private List<LinhaNegocioResponse> _linhasNegocio = new List<LinhaNegocioResponse>();
    private string linhaNegocio = null;
    
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

        var requestLinhasNegocio = await _linhaNegocioServices.GetLinhaNegocioAllAsync();
        if (requestLinhasNegocio.IsSuccessful)
        {
            _linhasNegocio = requestLinhasNegocio.Data;
        }
        else
        {
            _snackbar.Add(requestLinhasNegocio.Messages, Severity.Error);
            MudDialog.Close();
        }

        var linhaNegocioDescricao = _linhasNegocio.Where(linhaNegocio => linhaNegocio.Id == cliente.Cli_lhn_identi)
            .Select(linhaNegocio => linhaNegocio.Lhn_descri);
        linhaNegocio = linhaNegocioDescricao.FirstOrDefault();        
    }

    private async Task GeraAtendimentoPlantao()
    {
        atendimentoPlantaoRequest.Atd_tipatd = dadoListaTipoAtendimentoSelected;

        if (resolvidoPlantaoSelected == "SIM")
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

        if (string.IsNullOrWhiteSpace(ViewPreAtendimentoPlantao.Ptd_linjir))
        {
            atendimentoPlantaoRequest.Atd_linjir = null;
        }
        else
        {
            atendimentoPlantaoRequest.Atd_linjir = ViewPreAtendimentoPlantao.Ptd_linjir;
        }

        if (string.IsNullOrWhiteSpace(ViewPreAtendimentoPlantao.Ptd_verjir))
        {
            atendimentoPlantaoRequest.Atd_verjir = null;
        }
        else
        {
            atendimentoPlantaoRequest.Atd_verjir = ViewPreAtendimentoPlantao.Ptd_verjir;
        }

        atendimentoPlantaoRequest.Atd_cli_identi = cliente.Id;
        atendimentoPlantaoRequest.Atd_evoln1 = evolucaoN1Selected;
        atendimentoPlantaoRequest.Atd_nomal2 = dadoListaAnalistaN2Selected;
        atendimentoPlantaoRequest.Atd_titulo = ViewPreAtendimentoPlantao.Ptd_titulo;
        atendimentoPlantaoRequest.Atd_resumo = ViewPreAtendimentoPlantao.Ptd_resumo;
        atendimentoPlantaoRequest.Atd_datatd = DateTime.Now;
        atendimentoPlantaoRequest.Atd_status = "ABERTO";
        atendimentoPlantaoRequest.Atd_usubdd = "ViewDialog";
        atendimentoPlantaoRequest.Atd_usucri = 2;
        atendimentoPlantaoRequest.Atd_datcri = DateTime.Now;
        atendimentoPlantaoRequest.Atd_catnv1 = categoriaAtendimentoNivel1Selected;
        atendimentoPlantaoRequest.Atd_catnv2 = categoriaAtendimentoNivel2Selected;
        atendimentoPlantaoRequest.Atd_catnv3 = categoriaAtendimentoNivel3Selected;
        atendimentoPlantaoRequest.Atd_catnv4 = categoriaAtendimentoNivel4Selected;
        atendimentoPlantaoRequest.Atd_observ = justificativaEvolucao;
        atendimentoPlantaoRequest.Atd_ptd_identi = ViewPreAtendimentoPlantao.Id;
        atendimentoPlantaoRequest.Atd_usu_identi = ViewPreAtendimentoPlantao.Ptd_usu_identi;
        atendimentoPlantaoRequest.Atd_tipatd = dadoListaTipoAtendimentoSelected;
        atendimentoPlantaoRequest.Atd_jirarl = ViewPreAtendimentoPlantao.Ptd_jirarl;

        var requestAtendimento = await _atendimentoPlantaoServices.CreateAtendimentoPlantaoAsync(atendimentoPlantaoRequest);
        if (requestAtendimento.IsSuccessful)
        {
            _snackbar.Add("Atendimento criado com sucesso", Severity.Success);
            AtualizaPreAtendimento();
        }
        else
        {
            _snackbar.Add("Falha ao criar o Atendimento", Severity.Error);
        }

        MudDialog.Close();
    }

    private async Task AtualizaPreAtendimento()
    {
        updatePreAtendimentoPlantao = new UpdatePreAtendimentoPlantao
        {
            Id = ViewPreAtendimentoPlantao.Id,
            Ptd_cli_identi = ViewPreAtendimentoPlantao.Ptd_cli_identi,
            Ptd_usu_identi = ViewPreAtendimentoPlantao.Ptd_usu_identi,
            Ptd_titulo = ViewPreAtendimentoPlantao.Ptd_titulo,
            Ptd_datptd = ViewPreAtendimentoPlantao.Ptd_datptd,
            Ptd_tipptd = ViewPreAtendimentoPlantao.Ptd_tipptd,
            Ptd_critic = ViewPreAtendimentoPlantao.Ptd_critic,
            Ptd_resumo = ViewPreAtendimentoPlantao.Ptd_resumo,
            Ptd_numcha = ViewPreAtendimentoPlantao.Ptd_numcha,
            Ptd_jirarl = ViewPreAtendimentoPlantao.Ptd_jirarl,
            Ptd_numjir = ViewPreAtendimentoPlantao.Ptd_numjir,
            Ptd_diagn1 = ViewPreAtendimentoPlantao.Ptd_diagn1,            
            Ptd_reton2 = ViewPreAtendimentoPlantao.Ptd_reton2,
            Ptd_observ = ViewPreAtendimentoPlantao.Ptd_observ,
            Ptd_nomal1 = ViewPreAtendimentoPlantao.Ptd_nomal1,
            Ptd_numatd = ViewPreAtendimentoPlantao.Ptd_numatd,
            Ptd_usucri = ViewPreAtendimentoPlantao.Ptd_usucri,
            Ptd_usualt = ViewPreAtendimentoPlantao.Ptd_usualt,
            Ptd_datcri = ViewPreAtendimentoPlantao.Ptd_datcri,
            Ptd_datalt = ViewPreAtendimentoPlantao.Ptd_datalt,
            Ptd_usubdd = ViewPreAtendimentoPlantao.Ptd_usubdd,
            Ptd_linjir = ViewPreAtendimentoPlantao.Ptd_linjir,
            Ptd_verjir = ViewPreAtendimentoPlantao.Ptd_verjir,
            Ptd_status = "ATENDIMENTO GERADO"
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
