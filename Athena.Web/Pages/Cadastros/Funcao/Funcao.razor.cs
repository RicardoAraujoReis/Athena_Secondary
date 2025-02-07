using Athena.Web.Pages.Shared;
using Common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Funcao;

public partial class Funcao
{
    public List<FuncaoResponse> funcoes { get; set; } = new List<FuncaoResponse>();
    private bool _loading = true;
    private string searchFuncao = null;
    private string dataAlteracao = "---";

    protected override async Task OnInitializedAsync()
    {
        await LoadFuncaoListAsync();
    }

    private async Task LoadFuncaoListAsync()
    {
        var response = await _funcaoServices.GetFuncaoAllAsync();
        if (response.IsSuccessful)
        {
            funcoes = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);            
        }
        _loading = false;
    }

    private async void CreateFuncaoAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateFuncaoDialog>("Add Função", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadFuncaoListAsync();
        }
    }

    private async Task UpdateFuncaoAsync(int FuncaoId)
    {
        var parameters = new DialogParameters();

        var Funcao = funcoes.FirstOrDefault(Funcao => Funcao.Id == FuncaoId);

        parameters.Add(nameof(UpdateFuncaoDialog.UpdateFuncaoRequest), new UpdateFuncao
        {
            Id = FuncaoId,
            Fnc_descri = Funcao.Fnc_descri,
            Fnc_ativo = Funcao.Fnc_ativo,
            Fnc_usubdd = Funcao.Fnc_usubdd,
            Fnc_usucri = Funcao.Fnc_usucri,
            Fnc_usualt = Funcao.Fnc_usualt,
            Fnc_datcri = Funcao.Fnc_datcri,
            Fnc_datalt = Funcao.Fnc_datalt
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateFuncaoDialog>("Editar Função", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadFuncaoListAsync();
        }
    }

    private async Task DeleteFuncaoAsync(int FuncaoId, string FuncaoDescricao)
    {
        string message = $"Confirma a deleção da função {FuncaoDescricao} ?";

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

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar função", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _funcaoServices.DeleteFuncaoAsync(FuncaoId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadFuncaoListAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private bool FilterFuncaoAsync(FuncaoResponse FuncaoResponse) => FilterFuncao(FuncaoResponse, searchFuncao);

    private bool FilterFuncao(FuncaoResponse FuncaoResponse, string searchFuncao)
    {
        if (string.IsNullOrWhiteSpace(searchFuncao))
            return true;
        if (searchFuncao.Length == 1 && searchFuncao.ToUpper() == "S".ToUpper() &&
                FuncaoResponse.Fnc_ativo.Contains(searchFuncao, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchFuncao.Length == 1 && searchFuncao.ToUpper() == "N".ToUpper() &&
                FuncaoResponse.Fnc_ativo.Contains(searchFuncao, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchFuncao.Length > 1 && FuncaoResponse.Fnc_descri.Contains(searchFuncao, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
}
