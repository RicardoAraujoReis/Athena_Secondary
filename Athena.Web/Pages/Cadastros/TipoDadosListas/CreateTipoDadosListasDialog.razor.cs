using Athena.Web.Pages.Shared;
using Athena.Web.Validators.TipoDadosListasValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.TipoDadosListas;

public partial class CreateTipoDadosListasDialog
{
    [Parameter]
    public CreateTipoDadosListas CreateTipoDadosListasRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private TipoDadosListasValidator _validator = new();

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
        string message = $"Confirma a criação do Tipo Dado Lista?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.CreateConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateConfirmationDialog>("Criar novo Tipo Dado Lista", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            CreateTipoDadosListasRequest.Tid_usucri = 1;
            CreateTipoDadosListasRequest.Tid_usualt = null;
            CreateTipoDadosListasRequest.Tid_datcri = DateTime.Now;
            CreateTipoDadosListasRequest.Tid_datalt = null;
            CreateTipoDadosListasRequest.Tid_usubdd = "TidDialog";
            CreateTipoDadosListasRequest.Tid_descri = CreateTipoDadosListasRequest.Tid_descri.ToUpper();

            var response = await _tipoDadosListasServices.CreateTipoDadosListasAsync(CreateTipoDadosListasRequest);
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

    private void Cancel() => MudDialog.Cancel();
}
