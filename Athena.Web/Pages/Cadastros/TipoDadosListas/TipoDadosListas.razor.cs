using Athena.Web.Pages.Cadastros.TipoDadosListas;
using Athena.Web.Pages.Shared;
using Common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.TipoDadosListas;

public partial class TipoDadosListas
{
    public List<TipoDadosListasResponse> tipoDadosListas { get; set; } = new List<TipoDadosListasResponse>();
    private bool _loading = true;
    private string searchTipoDadosListas = null;

    protected override async Task OnInitializedAsync()
    {
        await LoadTipoDadosListasAsync();
    }

    private async Task LoadTipoDadosListasAsync()
    {
        var response = await _tipoDadosListasServices.GetTipoDadosListasAllAsync();
        if(response.IsSuccessful)
        {
            tipoDadosListas = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);
        }
        _loading = false;
    }

    private async void CreateTipoDadosListasAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateTipoDadosListasDialog>("Add Tipo de Dados Listas", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadTipoDadosListasAsync();
        }
    }

    private async Task UpdateTipoDadosListasAsync(int TipoDadosListasId)
    {
        var parameters = new DialogParameters();

        var TipoDadosListas = tipoDadosListas.FirstOrDefault(TipoDadosListas => TipoDadosListas.Id == TipoDadosListasId);

        parameters.Add(nameof(UpdateTipoDadosListasDialog.UpdateTipoDadosListasRequest), new UpdateTipoDadosListas
        {
            Id = TipoDadosListasId,
            Tid_descri = TipoDadosListas.Tid_descri,
            Tid_usubdd = TipoDadosListas.Tid_usubdd,
            Tid_usucri = TipoDadosListas.Tid_usucri,
            Tid_usualt = TipoDadosListas.Tid_usualt,
            Tid_datcri = TipoDadosListas.Tid_datcri,
            Tid_datalt = TipoDadosListas.Tid_datalt
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateTipoDadosListasDialog>("Editar Tipo de Dados Listas", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadTipoDadosListasAsync();
        }
    }

    private async Task DeleteTipoDadosListasAsync(int TipoDadosListasId, string TipoDadosListasDescricao)
    {
        string message = $"Confirma a deleção do Tipo de Dados Listas {TipoDadosListasDescricao} ?";

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

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar Tipo de Dados Listas", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _tipoDadosListasServices.DeleteTipoDadosListasAsync(TipoDadosListasId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadTipoDadosListasAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private bool FilterTipoDadosListasAsync(TipoDadosListasResponse TipoDadosListasResponse) => FilterTipoDadosListas(TipoDadosListasResponse, searchTipoDadosListas);

    private bool FilterTipoDadosListas(TipoDadosListasResponse TipoDadosListasResponse, string searchTipoDadosListas)
    {
        if (string.IsNullOrWhiteSpace(searchTipoDadosListas))
            return true;        
        if (searchTipoDadosListas.Length > 1 && TipoDadosListasResponse.Tid_descri.Contains(searchTipoDadosListas, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
}
