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
        CreateTipoDadosListasRequest.Tid_usucri = 1;
        CreateTipoDadosListasRequest.Tid_usualt = null;
        CreateTipoDadosListasRequest.Tid_datcri = DateTime.Now;
        CreateTipoDadosListasRequest.Tid_datalt = null;
        CreateTipoDadosListasRequest.Tid_usubdd = "TidDialog";        

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

    private void Cancel() => MudDialog.Cancel();
}
