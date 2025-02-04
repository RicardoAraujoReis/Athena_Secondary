using Athena.Web.Validators.CategoriaAtendimentoValidators;
using Common.Requests;
using Common.Responses;
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

    private List<CategoriaAtendimentoResponse> _categorias = new List<CategoriaAtendimentoResponse>();
    private string categoriaSelected = null;

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

        var categoriaPai = _categorias.Where(categoria => categoria.Cat_catpai == UpdateCategoriaAtendimentoRequest.Cat_catpai).FirstOrDefault();        
        categoriaSelected = categoriaPai.Cat_valor;
    }

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
        if (!string.IsNullOrWhiteSpace(categoriaSelected))
        {
            var categoriaId = _categorias.Where(categoria => categoria.Cat_valor == categoriaSelected).Select(categoria => categoria.Id);
            UpdateCategoriaAtendimentoRequest.Cat_catpai = categoriaId.FirstOrDefault();
        }

        var DescricaoCategoriaPai = await _categoriaAtendimentoServices.GetCategoriaAtendimentoByIdAsync(UpdateCategoriaAtendimentoRequest.Cat_catpai);

        if (DescricaoCategoriaPai.IsSuccessful)
        {
            UpdateCategoriaAtendimentoRequest.Cat_despai = DescricaoCategoriaPai.Data.Cat_valor;
        }
        UpdateCategoriaAtendimentoRequest.Cat_usualt = 1;
        UpdateCategoriaAtendimentoRequest.Cat_datalt = DateTime.Now;
        UpdateCategoriaAtendimentoRequest.Cat_usubdd = "LhnDialog";
        UpdateCategoriaAtendimentoRequest.Cat_valor = UpdateCategoriaAtendimentoRequest.Cat_valor.ToUpper();

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
