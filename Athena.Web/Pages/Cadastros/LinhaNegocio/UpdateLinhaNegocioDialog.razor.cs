using Athena.Web.Validators.LinhaNegocioValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.LinhaNegocio;

public partial class UpdateLinhaNegocioDialog
{
    [Parameter]
    public UpdateLinhaNegocio UpdateLinhaNegocioRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateLinhaNegocioValidator _validator = new();

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
        UpdateLinhaNegocioRequest.Lhn_usualt = 1;        
        UpdateLinhaNegocioRequest.Lhn_datalt = DateTime.Now;
        UpdateLinhaNegocioRequest.Lhn_usubdd = "LhnDialog";        

        var response = await _linhaNegocioServices.UpdateLinhaNegocioAsync(UpdateLinhaNegocioRequest);
        if (response.IsSuccessful)
        {
            _snackbar.Add(response.Messages, Severity.Success);
            MudDialog.Close();
        }
        else
        {
            foreach (var message in response.Messages)
            {
                _snackbar.Add(message.ToString(), Severity.Error);
            }
        }
    }

    void Cancel() => MudDialog.Cancel();
}
