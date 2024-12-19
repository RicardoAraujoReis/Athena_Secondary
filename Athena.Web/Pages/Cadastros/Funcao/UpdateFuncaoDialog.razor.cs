using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Funcao;

public partial class UpdateFuncaoDialog
{
    [Parameter]
    public UpdateFuncao UpdateFuncaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private async Task SaveAsync()
    {
        UpdateFuncaoRequest.Fnc_usualt = 1;
        UpdateFuncaoRequest.Fnc_datalt = DateTime.Now;
        UpdateFuncaoRequest.Fnc_usubdd = "LhnDialog";

        var response = await _funcaoServices.UpdateFuncaoAsync(UpdateFuncaoRequest);
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
