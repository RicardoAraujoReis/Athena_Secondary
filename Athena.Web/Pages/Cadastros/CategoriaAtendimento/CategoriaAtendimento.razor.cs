using Athena.Web.Pages.Cadastros.CategoriaAtendimento;
using Athena.Web.Pages.Shared;
using Common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.CategoriaAtendimento;

public partial class CategoriaAtendimento
{
    public List<CategoriaAtendimentoResponse> CategoriaAtendimentos { get; set; } = new List<CategoriaAtendimentoResponse>();
    private bool _loading = true;
    private string searchCategoriaAtendimento = null;

    protected override async Task OnInitializedAsync()
    {
        await LoadCategoriaAtendimentoListAsync();
    }

    private async Task LoadCategoriaAtendimentoListAsync()
    {
        var response = await _categoriaAtendimentoServices.GetCategoriaAtendimentoAllAsync();
        if (response.IsSuccessful)
        {
            CategoriaAtendimentos = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);
        }
        _loading = false;
    }

    private async void CreateCategoriaAtendimentoAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateCategoriaAtendimentoDialog>("Add Categoria de Atendimento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadCategoriaAtendimentoListAsync();
        }
    }

    private async Task UpdateCategoriaAtendimentoAsync(int CategoriaAtendimentoId)
    {
        var parameters = new DialogParameters();

        var CategoriaAtendimento = CategoriaAtendimentos.FirstOrDefault(CategoriaAtendimento => CategoriaAtendimento.Id == CategoriaAtendimentoId);

        parameters.Add(nameof(UpdateCategoriaAtendimentoDialog.UpdateCategoriaAtendimentoRequest), new UpdateCategoriaAtendimento
        {
            Id = CategoriaAtendimentoId,
            Cat_valor = CategoriaAtendimento.Cat_valor,
            Cat_catpai = CategoriaAtendimento.Cat_catpai,
            Cat_despai = CategoriaAtendimento.Cat_despai,
            Cat_nivel  = CategoriaAtendimento.Cat_nivel,
            Cat_ativo = CategoriaAtendimento.Cat_ativo,
            Cat_usubdd = CategoriaAtendimento.Cat_usubdd,
            Cat_usucri = CategoriaAtendimento.Cat_usucri,
            Cat_usualt = CategoriaAtendimento.Cat_usualt,
            Cat_datcri = CategoriaAtendimento.Cat_datcri,
            Cat_datalt = CategoriaAtendimento.Cat_datalt            
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateCategoriaAtendimentoDialog>("Editar Categoria de Atendimento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadCategoriaAtendimentoListAsync();
        }
    }

    private async Task DeleteCategoriaAtendimentoAsync(int CategoriaAtendimentoId, string CategoriaAtendimentoDescricao)
    {
        string message = $"Confirma a deleção da Categoria de Atendimento {CategoriaAtendimentoDescricao} ?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.DeleteConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar Categoria de Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _categoriaAtendimentoServices.DeleteCategoriaAtendimentoAsync(CategoriaAtendimentoId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadCategoriaAtendimentoListAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private bool FilterCategoriaAtendimentoAsync(CategoriaAtendimentoResponse CategoriaAtendimentoResponse) => 
        FilterCategoriaAtendimento(CategoriaAtendimentoResponse, searchCategoriaAtendimento);

    private bool FilterCategoriaAtendimento(CategoriaAtendimentoResponse CategoriaAtendimentoResponse, string searchCategoriaAtendimento)
    {
        if (string.IsNullOrWhiteSpace(searchCategoriaAtendimento))
            return true;
        /*if (searchCategoriaAtendimento.Length == 1 && searchCategoriaAtendimento.ToUpper() == "S".ToUpper() &&
                CategoriaAtendimentoResponse.Cat_ativo.Contains(searchCategoriaAtendimento, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchCategoriaAtendimento.Length == 1 && searchCategoriaAtendimento.ToUpper() == "N".ToUpper() &&
                CategoriaAtendimentoResponse.Cat_ativo.Contains(searchCategoriaAtendimento, StringComparison.OrdinalIgnoreCase))
            return true;*/
        if (searchCategoriaAtendimento.Length > 1 && CategoriaAtendimentoResponse.Cat_valor.Contains(searchCategoriaAtendimento, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
}
