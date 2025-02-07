using Athena.Web.Pages.Cadastros.DadosListas;
using Athena.Web.Pages.Shared;
using Common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.DadosListas;

public partial class DadosListas
{
    public List<DadosListasResponse> dadosListas { get; set; } = new List<DadosListasResponse>();
    private bool _loading = true;
    private string searchDadosListas = null;
    private string dataAlteracao = "---";

    protected override async Task OnInitializedAsync()
    {
        await LoadDadosListasAsync();
    }

    private async Task LoadDadosListasAsync()
    {
        var response = await _dadosListasServices.GetDadosListasAllAsync();
        if (response.IsSuccessful)
        {
            dadosListas = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);
        }
        _loading = false;
    }

    private async void CreateDadosListasAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateDadosListasDialog>("Add Dados Listas", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadDadosListasAsync();
        }
    }

    private async Task UpdateDadosListasAsync(int DadosListasId)
    {
        var parameters = new DialogParameters();

        var DadosListas = dadosListas.FirstOrDefault(DadosListas => DadosListas.Id == DadosListasId);

        parameters.Add(nameof(UpdateDadosListasDialog.UpdateDadosListasRequest), new UpdateDadosListas
        {
            Id = DadosListasId,
            Dal_valor = DadosListas.Dal_valor,
            Dal_usubdd = DadosListas.Dal_usubdd,
            Dal_usucri = DadosListas.Dal_usucri,
            Dal_usualt = DadosListas.Dal_usualt,
            Dal_datcri = DadosListas.Dal_datcri,
            Dal_datalt = DadosListas.Dal_datalt,
            Dal_tid_identi = DadosListas.Dal_tid_identi
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateDadosListasDialog>("Editar Dados Listas", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadDadosListasAsync();
        }
    }

    private async Task DeleteDadosListasAsync(int DadosListasId, string DadosListasDescricao)
    {
        string message = $"Confirma a deleção do Dados Listas {DadosListasDescricao} ?";

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

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar Dados Listas", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _dadosListasServices.DeleteDadosListasAsync(DadosListasId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadDadosListasAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private bool FilterDadosListasAsync(DadosListasResponse DadosListasResponse) => FilterDadosListas(DadosListasResponse, searchDadosListas);

    private bool FilterDadosListas(DadosListasResponse DadosListasResponse, string searchDadosListas)
    {
        if (string.IsNullOrWhiteSpace(searchDadosListas))
            return true;
        if (searchDadosListas.Length > 1 && DadosListasResponse.Dal_valor.Contains(searchDadosListas, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
}
