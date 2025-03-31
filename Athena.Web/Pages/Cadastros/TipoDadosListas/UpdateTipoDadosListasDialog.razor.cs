using Athena.Web.Pages.Shared;
using Athena.Web.Validators.TipoDadosListasValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.TipoDadosListas;

public partial class UpdateTipoDadosListasDialog
{
    [Parameter]
    public UpdateTipoDadosListas UpdateTipoDadosListasRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateTipoDadosListasValidator _validator = new();

    private async Task SubmitAsync()
    {
        await _form.Validate();

        if (CheckForm())
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
        string message = $"Confirma a atualização do Tipo Dado Lista?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.UpdateConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateConfirmationDialog>("Atualizar o Tipo Dado Lista", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            UpdateTipoDadosListasRequest.Tid_usualt = 1;
            UpdateTipoDadosListasRequest.Tid_datalt = DateTime.Now;
            UpdateTipoDadosListasRequest.Tid_usubdd = "DalDialog";

            var response = await _tipoDadosListasServices.UpdateTipoDadosListasAsync(UpdateTipoDadosListasRequest);
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
    }

    void Cancel() => MudDialog.Cancel();
}
