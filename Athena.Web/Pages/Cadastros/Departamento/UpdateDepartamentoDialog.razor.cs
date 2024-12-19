using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Departamento;

public partial class UpdateDepartamentoDialog
{
    [Parameter]
    public UpdateDepartamento UpdateDepartamentoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private async Task SaveAsync()
    {
        UpdateDepartamentoRequest.Dpt_usualt = 1;
        UpdateDepartamentoRequest.Dpt_datalt = DateTime.Now;
        UpdateDepartamentoRequest.Dpt_usubdd = "LhnDialog";

        var response = await _departamentoServices.UpdateDepartamentoAsync(UpdateDepartamentoRequest);
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
