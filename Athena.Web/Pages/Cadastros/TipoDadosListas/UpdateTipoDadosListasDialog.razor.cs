using Athena.Web.Validators.CategoriaAtendimentoValidators;
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

    void Cancel() => MudDialog.Cancel();
}
