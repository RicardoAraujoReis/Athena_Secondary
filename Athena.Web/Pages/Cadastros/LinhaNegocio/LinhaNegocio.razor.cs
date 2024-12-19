using Athena.Web.Pages.Shared;
using Common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.LinhaNegocio;

public partial class LinhaNegocio
{
    public List<LinhaNegocioResponse> linhaNegocios { get; set; } = new List<LinhaNegocioResponse>();
    private bool _loading = true;
    private string searchLinhaNegocio = null;
    private string filterByAtivo = null;
    private LinhaNegocioResponse selectedItem = null;

    protected override async Task OnInitializedAsync()
    {
        await LoadLinhaNegocioListAsync();
    }

    private async Task LoadLinhaNegocioListAsync()
    {
        var response = await _linhaNegocioServices.GetLinhaNegocioAllAsync();
        if (response.IsSuccessful)
        {
            linhaNegocios = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);
        }
        _loading = false;
    }

    private async void CreateLinhaNegocioAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateLinhaNegocioDialog>("Add Linha de Negócio", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadLinhaNegocioListAsync();
        }
    }

    private async Task UpdateLinhaNegocioAsync(int linhaNegocioId)
    {
        var parameters = new DialogParameters();

        var linhaNegocio = linhaNegocios.FirstOrDefault(linhaNegocio => linhaNegocio.Id == linhaNegocioId);

        parameters.Add(nameof(UpdateLinhaNegocioDialog.UpdateLinhaNegocioRequest), new UpdateLinhaNegocio
        {
            Id = linhaNegocioId,
            Lhn_descri = linhaNegocio.Lhn_descri,
            Lhn_ativo = linhaNegocio.Lhn_ativo,
            Lhn_usubdd = linhaNegocio.Lhn_usubdd,
            Lhn_usucri = linhaNegocio.Lhn_usucri,
            Lhn_usualt = linhaNegocio.Lhn_usualt,
            Lhn_datcri = linhaNegocio.Lhn_datcri,
            Lhn_datalt = linhaNegocio.Lhn_datalt
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateLinhaNegocioDialog>("Editar Linha de Negócio", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadLinhaNegocioListAsync();
        }
    }

    private async Task DeleteLinhaNegocioAsync(int linhaNegocioId, string linhaNegocioDescricao)
    {
        string message = $"Confirma a deleção da linha de negócio {linhaNegocioDescricao} ?";

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

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar Linha de Negócio", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _linhaNegocioServices.DeleteLinhaNegocioAsync(linhaNegocioId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadLinhaNegocioListAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }    

    private bool FilterLinhaNegocioAsync(LinhaNegocioResponse linhaNegocioResponse) => FilterLinhaNegocio(linhaNegocioResponse, searchLinhaNegocio);

    private bool FilterLinhaNegocio(LinhaNegocioResponse linhaNegocioResponse, string searchLinhaNegocio)
    {
        if (string.IsNullOrWhiteSpace(searchLinhaNegocio))
            return true;
        if (searchLinhaNegocio.Length == 1 && searchLinhaNegocio.ToUpper() == "S".ToUpper() && 
                linhaNegocioResponse.Lhn_ativo.Contains(searchLinhaNegocio, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchLinhaNegocio.Length == 1 && searchLinhaNegocio.ToUpper() == "N".ToUpper() && 
                linhaNegocioResponse.Lhn_ativo.Contains(searchLinhaNegocio, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchLinhaNegocio.Length > 1 && linhaNegocioResponse.Lhn_descri.Contains(searchLinhaNegocio, StringComparison.OrdinalIgnoreCase))
            return true;    
        return false;
    }
}
