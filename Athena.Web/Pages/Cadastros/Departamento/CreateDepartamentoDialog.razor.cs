using Athena.Web.Pages.Shared;
using Athena.Web.Validators.DepartamentoValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Departamento;

public partial class CreateDepartamentoDialog
{
    [Parameter]
    public CreateDepartamento CreateDepartamentoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private DepartamentoValidator _validator = new();

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
        string message = $"Confirma a criação do Departamento?";

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

        var dialog = _dialogService.Show<CreateConfirmationDialog>("Criar novo cliente", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            CreateDepartamentoRequest.Dpt_usucri = 1;
            CreateDepartamentoRequest.Dpt_usualt = null;
            CreateDepartamentoRequest.Dpt_datcri = DateTime.Now;
            CreateDepartamentoRequest.Dpt_datalt = null;
            CreateDepartamentoRequest.Dpt_usubdd = "DptDialog";
            CreateDepartamentoRequest.Dpt_ativo = "S";
            CreateDepartamentoRequest.Dpt_descri = CreateDepartamentoRequest.Dpt_descri.ToUpper();

            var response = await _departamentoServices.CreateDepartamentoAsync(CreateDepartamentoRequest);
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
