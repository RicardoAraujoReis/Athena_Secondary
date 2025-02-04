using Athena.Web.Validators.ClienteValidators;
using common.Requests;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Cliente;

public partial class CreateClienteDialog
{
    [Parameter]
    public CreateCliente CreateClienteRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private ClienteValidator _validator = new();

    private List<LinhaNegocioResponse> _linhasNegocio = new List<LinhaNegocioResponse>();    
    private string linhaNegocioSelected = null;

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
        CreateClienteRequest.Cli_usucri = 1;
        CreateClienteRequest.Cli_usualt = null;
        CreateClienteRequest.Cli_datcri = DateTime.Now;
        CreateClienteRequest.Cli_datalt = null;
        CreateClienteRequest.Cli_usubdd = "LhnDialog";
        CreateClienteRequest.Cli_ativo = "S";
        CreateClienteRequest.Cli_descri = CreateClienteRequest.Cli_descri.ToUpper();

        if (!string.IsNullOrWhiteSpace(linhaNegocioSelected))
        {
            var linhaNegocioId = _linhasNegocio.Where(linhaNegocio => linhaNegocio.Lhn_descri == linhaNegocioSelected).Select(linhaNegocio => linhaNegocio.Id);
            CreateClienteRequest.Cli_lhn_identi = linhaNegocioId.FirstOrDefault();
        }

        var response = await _clienteServices.CreateClienteAsync(CreateClienteRequest);
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

    private void Cancel() => MudDialog.Cancel();
}
