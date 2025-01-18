using Athena.Web.Validators.CategoriaAtendimentoValidators;
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

    private CategoriaAtendimentoValidator _validator = new();

    private async Task SubmitAsync()
    {
        await _form.Validate();

        if(_form.IsValid)
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
        var DescricaoCategoriaPai = await _categoriaAtendimentoServices.GetCategoriaAtendimentoByIdAsync(CreateCategoriaAtendimentoRequest.Cat_catpai);

        if(DescricaoCategoriaPai.IsSuccessful)
        {
            CreateCategoriaAtendimentoRequest.Cat_despai = DescricaoCategoriaPai.Data.Cat_valor;
        }
        CreateCategoriaAtendimentoRequest.Cat_usucri = 1;
        CreateCategoriaAtendimentoRequest.Cat_usualt = null;
        CreateCategoriaAtendimentoRequest.Cat_datcri = DateTime.Now;
        CreateCategoriaAtendimentoRequest.Cat_datalt = null;
        CreateCategoriaAtendimentoRequest.Cat_usubdd = "LhnDialog";
        CreateCategoriaAtendimentoRequest.Cat_ativo = "S";
        

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
