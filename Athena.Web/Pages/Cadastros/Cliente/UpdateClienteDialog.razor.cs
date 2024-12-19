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
