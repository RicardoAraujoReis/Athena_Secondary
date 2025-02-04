using Athena.Web.Validators.ClienteValidators;
using common.Requests;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;

namespace Athena.Web.Pages.Cadastros.Cliente;

public partial class UpdateClienteDialog
{
    [Parameter]
    public UpdateCliente UpdateClienteRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateClienteValidator _validator = new();

    private List<LinhaNegocioResponse> _linhasNegocio = new List<LinhaNegocioResponse>();    
    
    private string linhaNegocioSelected = null;

    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();

    private List<string> nomeDadosListasRegistroAtivo = null;
    private string dadoListaRegistroAtivoSelected = null;

    protected override async Task OnInitializedAsync()
    {
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
        
        var linhaNegocioAtual = _linhasNegocio.Where(linhaNegocio => linhaNegocio.Id == UpdateClienteRequest.Cli_lhn_identi).FirstOrDefault();
        linhaNegocioSelected = linhaNegocioAtual.Lhn_descri;

        var statusAtualCliente = UpdateClienteRequest.Cli_ativo.ToUpper();
        dadoListaRegistroAtivoSelected = statusAtualCliente;

        var requestDadosListas = await _dadosListasServices.GetDadosListasAllAsync();
        if (requestDadosListas.IsSuccessful)
        {
            _dadosListas = requestDadosListas.Data;
        }
        nomeDadosListasRegistroAtivo = _dadosListas.Where(dados => dados.Dal_tid_descri == "REGISTRO ATIVO").Select(dados => dados.Dal_valor).ToList();        
    }

    private async Task SubmitAsync()
    {
        await _form.Validate();

        if (_form.IsValid)
        {
            await SaveAsync();
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
        UpdateClienteRequest.Cli_usualt = 1;        
        UpdateClienteRequest.Cli_datalt = DateTime.Now;
        UpdateClienteRequest.Cli_usubdd = "LhnDialog";
        UpdateClienteRequest.Cli_descri = UpdateClienteRequest.Cli_descri.ToUpper();

        if (!string.IsNullOrWhiteSpace(linhaNegocioSelected))
        {
            var linhaNegocioId = _linhasNegocio.Where(linhaNegocio => linhaNegocio.Lhn_descri == linhaNegocioSelected).Select(linhaNegocio => linhaNegocio.Id);
            UpdateClienteRequest.Cli_lhn_identi = linhaNegocioId.FirstOrDefault();
        }

        if (!string.IsNullOrWhiteSpace(dadoListaRegistroAtivoSelected))
        {
            if (dadoListaRegistroAtivoSelected.Equals("NAO"))
            {
                UpdateClienteRequest.Cli_ativo = "N";
            }
            else
            {
                UpdateClienteRequest.Cli_ativo = "S";
            }
        }

        var response = await _clienteServices.UpdateClienteAsync(UpdateClienteRequest);
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

    void Cancel() => MudDialog.Cancel();
}
