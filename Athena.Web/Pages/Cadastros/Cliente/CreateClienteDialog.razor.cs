using common.Requests;
using Common.Requests;
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
    private async Task SaveAsync()
    {
        CreateClienteRequest.Cli_usucri = 1;
        CreateClienteRequest.Cli_usualt = null;
        CreateClienteRequest.Cli_datcri = DateTime.Now;
        CreateClienteRequest.Cli_datalt = null;
        CreateClienteRequest.Cli_usubdd = "LhnDialog";
        CreateClienteRequest.Cli_ativo = "S";

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
