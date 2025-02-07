using Athena.Web.Pages.Shared;
using common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Cliente;

public partial class Cliente
{
    public List<ClienteResponse> clientes { get; set; } = new List<ClienteResponse>();
    private bool _loading = true;
    private string searchCliente = null;

    private string dataAlteracao = "---";

    protected override async Task OnInitializedAsync()
    {
        await LoadClienteListAsync();
    }

    private async Task LoadClienteListAsync()
    {
        var response = await _clienteServices.GetClienteAllAsync();
        if (response.IsSuccessful)
        {
            clientes = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);            
        }
        _loading = false;
    }

    private async void CreateClienteAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateClienteDialog>("Add Cliente", parameters, options);

        var result = await dialog.Result;                    

        if (!result.Canceled)
        {
            await LoadClienteListAsync();
        }
    }

    private async Task UpdateClienteAsync(int ClienteId)
    {
        var parameters = new DialogParameters();

        var Cliente = clientes.FirstOrDefault(Cliente => Cliente.Id == ClienteId);

        parameters.Add(nameof(UpdateClienteDialog.UpdateClienteRequest), new UpdateCliente
        {
            Id = ClienteId,
            Cli_descri = Cliente.Cli_descri,
            Cli_ativo = Cliente.Cli_ativo,
            Cli_usubdd = Cliente.Cli_usubdd,
            Cli_usucri = Cliente.Cli_usucri,
            Cli_usualt = Cliente.Cli_usualt,
            Cli_datcri = Cliente.Cli_datcri,
            Cli_datalt = Cliente.Cli_datalt,
            Cli_lhn_identi = Cliente.Cli_lhn_identi
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateClienteDialog>("Editar Cliente", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadClienteListAsync();
        }
    }

    private async Task DeleteClienteAsync(int ClienteId, string ClienteDescricao)
    {
        string message = $"Confirma a deleção do cliente {ClienteDescricao} ?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.DeleteConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar cliente", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _clienteServices.DeleteClienteAsync(ClienteId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadClienteListAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private bool FilterClienteAsync(ClienteResponse clienteResponse) => FilterCliente(clienteResponse, searchCliente);

    private bool FilterCliente(ClienteResponse clienteResponse, string searchCliente)
    {
        if (string.IsNullOrWhiteSpace(searchCliente))
            return true;
        if (searchCliente.Length == 1 && searchCliente.ToUpper() == "S".ToUpper() &&
                clienteResponse.Cli_ativo.Contains(searchCliente, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchCliente.Length == 1 && searchCliente.ToUpper() == "N".ToUpper() &&
                clienteResponse.Cli_ativo.Contains(searchCliente, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchCliente.Length > 1 && clienteResponse.Cli_descri.Contains(searchCliente, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }    
}
    
