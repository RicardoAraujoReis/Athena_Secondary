using Athena.Web.Validators.CategoriaAtendimentoValidators;
using Common.Requests;
using Common.Responses;
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

    private List<CategoriaAtendimentoResponse> _categorias = new List<CategoriaAtendimentoResponse>();
    private int? categoriaSelected;    

    protected override async Task OnInitializedAsync()
    {
        var categoriaRequest = await _categoriaAtendimentoServices.GetCategoriaAtendimentoAllAsync();

        if (categoriaRequest.IsSuccessful)
        {
            _categorias = categoriaRequest.Data;
        }
        else
        {
            _snackbar.Add(categoriaRequest.Messages, Severity.Error);
            MudDialog.Close();
        }
    }

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
        var DescricaoCategoriaPai = await _categoriaAtendimentoServices.GetCategoriaAtendimentoByIdAsync(categoriaSelected.Value);

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
        CreateCategoriaAtendimentoRequest.Cat_valor = CreateCategoriaAtendimentoRequest.Cat_valor.ToUpper();

        if (DescricaoCategoriaPai.Data.Cat_valor == CreateCategoriaAtendimentoRequest.Cat_valor)
        {
            _snackbar.Add("Categoria Pai deve ser diferente da Categoria", Severity.Error);
            MudDialog.Close();
        }
        else
        {
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
    }

    private void Cancel() => MudDialog.Cancel();
}
