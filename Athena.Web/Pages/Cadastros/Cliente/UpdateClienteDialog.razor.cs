using Athena.Web.Validators.ClienteValidators;
using common.Requests;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Cliente;

public partial class UpdateClienteDialog
{
    [Parameter]
    public UpdateCliente UpdateClienteRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateClienteValidator _validator = new();

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
