using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.CategoriaAtendimento;

public partial class CreateCategoriaAtendimentoDialog
{
    [Parameter]
    public CreateCategoriaAtendimento CreateCategoriaAtendimentoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;
    private async Task SaveAsync()
    {
        CreateCategoriaAtendimentoRequest.Cat_usucri = 1;
        CreateCategoriaAtendimentoRequest.Cat_usualt = null;
        CreateCategoriaAtendimentoRequest.Cat_datcri = DateTime.Now;
        CreateCategoriaAtendimentoRequest.Cat_datalt = null;
        CreateCategoriaAtendimentoRequest.Cat_usubdd = "LhnDialog";
        //CreateCategoriaAtendimentoRequest.Cat_ativo = "S";

        var response = await _categoriaAtendimentoServices.CreateCategoriaAtendimentoAsync(CreateCategoriaAtendimentoRequest);
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
