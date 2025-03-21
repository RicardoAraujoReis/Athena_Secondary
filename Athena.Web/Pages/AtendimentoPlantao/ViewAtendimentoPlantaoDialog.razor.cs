using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.AtendimentoPlantao;

public partial class ViewAtendimentoPlantaoDialog
{
    [Parameter]
    public ViewAtendimentoPlantao ViewAtendimentoPlantao { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private ClienteResponse cliente = null;
    private string jiraRelacionado = null;
    private string jiraCriado = null;    
    private string clienteDescricao = null;        
    private string criticidade = null;
    private string resolveriaN1 = null;
    private string resolveriaN1SeTeste = null;
    private string resolvidoPlantao = null;    

    private List<LinhaNegocioResponse> _linhasNegocio = new List<LinhaNegocioResponse>();
    private string linhaNegocio = null;

    protected override async Task OnInitializedAsync()
    {
        var clienteAtualRequest = await _clienteServices.GetClienteByIdAsync(ViewAtendimentoPlantao.Atd_cli_identi);

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

        var criticidadeAtual = ViewAtendimentoPlantao.Atd_critic;

        if (criticidadeAtual is not null)
        {
            if (criticidadeAtual.Equals("T"))
            {
                criticidade = "TRIVIAL";
            }
            else if (criticidadeAtual.Equals("B"))
            {
                criticidade = "BAIXA";
            }
            else if (criticidadeAtual.Equals("M"))
            {
                criticidade = "MEDIA";
            }
            else if (criticidadeAtual.Equals("A"))
            {
                criticidade = "ALTA";
            }
            else
            {
                criticidade = "CRITICA";
            }
        }

        if (ViewAtendimentoPlantao.Atd_jirarl == "S")
        {
            jiraRelacionado = "SIM";
        }
        else
        {
            jiraRelacionado = "NAO";
        }

        if(ViewAtendimentoPlantao.Atd_resn1 == "S")
        {
            resolveriaN1 = "SIM";
        }
        else
        {
            resolveriaN1 = "NAO";
        }

        if(ViewAtendimentoPlantao.Atd_ren1hm == "S")
        {
            resolveriaN1SeTeste = "SIM";
        }
        else
        {
            resolveriaN1SeTeste = "NAO";
        }

        if(ViewAtendimentoPlantao.Atd_resplt == "S")
        {
            resolvidoPlantao = "SIM";
        }
        else
        {
            resolvidoPlantao = "NAO";
        }
        
        if(ViewAtendimentoPlantao.Atd_crijir == "S")
        {
            jiraCriado = "SIM";
        }
        else
        {
            jiraCriado = "NAO";
        }
    }
}
