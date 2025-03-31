using Athena.Web.Pages.Shared;
using Athena.Web.Validators.FuncaoValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Funcao;

public partial class CreateFuncaoDialog
{
    [Parameter]
    public CreateFuncao CreateFuncaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private FuncaoValidator _validator = new();

    private async Task SubmitAsync()
    {
        await _form.Validate();

        if (CheckForm())
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
        string message = $"Confirma a criação da Função?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.CreateConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreateConfirmationDialog>("Criar nova Função", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            CreateFuncaoRequest.Fnc_usucri = 1;
            CreateFuncaoRequest.Fnc_usualt = null;
            CreateFuncaoRequest.Fnc_datcri = DateTime.Now;
            CreateFuncaoRequest.Fnc_datalt = null;
            CreateFuncaoRequest.Fnc_usubdd = "FncDialog";
            CreateFuncaoRequest.Fnc_ativo = "S";
            CreateFuncaoRequest.Fnc_descri = CreateFuncaoRequest.Fnc_descri.ToUpper();

            var response = await _funcaoServices.CreateFuncaoAsync(CreateFuncaoRequest);
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
