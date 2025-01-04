using Athena.Web.Validators.FuncaoValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Funcao;

public partial class CreateFuncaoDialog
{
    [Parameter]
    public CreateFuncao CreateFuncaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private FuncaoValidator _validator = new();

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
        CreateFuncaoRequest.Fnc_usucri = 1;
        CreateFuncaoRequest.Fnc_usualt = null;
        CreateFuncaoRequest.Fnc_datcri = DateTime.Now;
        CreateFuncaoRequest.Fnc_datalt = null;
        CreateFuncaoRequest.Fnc_usubdd = "LhnDialog";
        CreateFuncaoRequest.Fnc_ativo = "S";

        var response = await _funcaoServices.CreateFuncaoAsync(CreateFuncaoRequest);
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
