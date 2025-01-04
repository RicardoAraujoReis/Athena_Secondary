using Athena.Web.Validators.LinhaNegocioValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.LinhaNegocio;

public partial class CreateLinhaNegocioDialog
{
    [Parameter]
    public CreateLinhaNegocio CreateLinhaNegocioRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }
    
    MudForm _form = default;

    private LinhaNegocioValidator _validator = new();

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
        CreateLinhaNegocioRequest.Lhn_usucri = 1;
        CreateLinhaNegocioRequest.Lhn_usualt = null;
        CreateLinhaNegocioRequest.Lhn_datcri = DateTime.Now;
        CreateLinhaNegocioRequest.Lhn_datalt = null;
        CreateLinhaNegocioRequest.Lhn_usubdd = "LhnDialog";
        CreateLinhaNegocioRequest.Lhn_ativo = "S";

        var response = await _linhaNegocioServices.CreateLinhaNegocioAsync(CreateLinhaNegocioRequest);
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
