using Athena.Web.Validators.CategoriaAtendimentoValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.CategoriaAtendimento;

public partial class UpdateCategoriaAtendimentoDialog
{
    [Parameter]
    public UpdateCategoriaAtendimento UpdateCategoriaAtendimentoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateCategoriaAtendimentoValidator _validator = new();

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
        UpdateCategoriaAtendimentoRequest.Cat_usualt = 1;
        UpdateCategoriaAtendimentoRequest.Cat_datalt = DateTime.Now;
        UpdateCategoriaAtendimentoRequest.Cat_usubdd = "LhnDialog";

        var response = await _categoriaAtendimentoServices.UpdateCategoriaAtendimentoAsync(UpdateCategoriaAtendimentoRequest);
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
