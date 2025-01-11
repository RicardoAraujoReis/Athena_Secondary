using Athena.Web.Validators.DadosListasValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.DadosListas;

public partial class CreateDadosListasDialog
{
    [Parameter]
    public CreateDadosListas CreateDadosListasRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private DadosListasValidator _validator = new();

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
        CreateDadosListasRequest.Dal_usucri = 1;
        CreateDadosListasRequest.Dal_usualt = null;
        CreateDadosListasRequest.Dal_datcri = DateTime.Now;
        CreateDadosListasRequest.Dal_datalt = null;
        CreateDadosListasRequest.Dal_usubdd = "DalDialog";

        var response = await _dadosListasServices.CreateDadosListasAsync(CreateDadosListasRequest);
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
