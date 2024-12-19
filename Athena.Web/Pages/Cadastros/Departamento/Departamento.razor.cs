using Athena.Web.Pages.Cadastros.Cliente;
using Athena.Web.Pages.Shared;
using common.Requests;
using Common.Requests;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Departamento;

public partial class Departamento
{
    public List<DepartamentoResponse> departamentos { get; set; } = new List<DepartamentoResponse>();    
    private bool _loading = true;
    private string searchDepartamento = null;

    protected override async Task OnInitializedAsync()
    {
        await LoadDepartamentoListAsync();
    }

    private async Task LoadDepartamentoListAsync()
    {
        var response = await _departamentoServices.GetDepartamentoAllAsync();
        if (response.IsSuccessful)
        {
            departamentos = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);            
        }
        _loading = false;
    }

    private async void CreateDepartamentoAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateDepartamentoDialog>("Add departamento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadDepartamentoListAsync();
        }
    }

    private async Task UpdateDepartamentoAsync(int departamentoId)
    {
        var parameters = new DialogParameters();

        var Departamento = departamentos.FirstOrDefault(Departamento => Departamento.Id == departamentoId);

        parameters.Add(nameof(UpdateDepartamentoDialog.UpdateDepartamentoRequest), new UpdateDepartamento
        {
            Id = departamentoId,
            Dpt_descri = Departamento.Dpt_descri,
            Dpt_ativo = Departamento.Dpt_ativo,
            Dpt_usubdd = Departamento.Dpt_usubdd,
            Dpt_usucri = Departamento.Dpt_usucri,
            Dpt_usualt = Departamento.Dpt_usualt,
            Dpt_datcri = Departamento.Dpt_datcri,
            Dpt_datalt = Departamento.Dpt_datalt
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateDepartamentoDialog>("Editar Departamento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadDepartamentoListAsync();
        }
    }

    private async Task DeleteDepartamentoAsync(int departamentoId, string departamentoDescricao)
    {
        string message = $"Confirma a deleção do departamento {departamentoDescricao} ?";

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

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar departamento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _departamentoServices.DeleteDepartamentoAsync(departamentoId);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadDepartamentoListAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }

    private bool FilterDepartamentoAsync(DepartamentoResponse departamentoResponse) => FilterDepartamento(departamentoResponse, searchDepartamento);

    private bool FilterDepartamento(DepartamentoResponse departamentoResponse, string searchDepartamento)
    {
        if (string.IsNullOrWhiteSpace(searchDepartamento))
            return true;
        if (searchDepartamento.Length == 1 && searchDepartamento.ToUpper() == "S".ToUpper() &&
                departamentoResponse.Dpt_ativo.Contains(searchDepartamento, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchDepartamento.Length == 1 && searchDepartamento.ToUpper() == "N".ToUpper() &&
                departamentoResponse.Dpt_ativo.Contains(searchDepartamento, StringComparison.OrdinalIgnoreCase))
            return true;
        if (searchDepartamento.Length > 1 && departamentoResponse.Dpt_descri.Contains(searchDepartamento, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
}
