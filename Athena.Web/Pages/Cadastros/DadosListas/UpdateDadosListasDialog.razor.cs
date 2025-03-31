using Athena.Web.Pages.Shared;
using Athena.Web.Validators.DadosListasValidators;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.DadosListas;

public partial class UpdateDadosListasDialog
{
    [Parameter]
    public UpdateDadosListas UpdateDadosListasRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateDadosListasValidator _validator = new();

    private List<TipoDadosListasResponse> _tiposDadosListas = new List<TipoDadosListasResponse>();    
    private string tipoDadosListasSelected = null;

    private ListaAplicacaoDadoLista aplicacao = new ListaAplicacaoDadoLista();
    private List<string> listaAplicacao = new List<string>();
    private string aplicacaoSelected = null;

    protected override async Task OnInitializedAsync()
    {
        var requestTipoDadosListas = await _tipoDadosListasServices.GetTipoDadosListasAllAsync();
        if (requestTipoDadosListas.IsSuccessful)
        {
            _tiposDadosListas = requestTipoDadosListas.Data;
        }
        else
        {
            _snackbar.Add(requestTipoDadosListas.Messages, Severity.Error);
            MudDialog.Close();
        }

        tipoDadosListasSelected = _tiposDadosListas.Where(tipo => tipo.Id == UpdateDadosListasRequest.Dal_tid_identi).Select(tipo => tipo.Tid_descri).FirstOrDefault();
        listaAplicacao = new List<string>(Enum.GetNames(typeof(ListaAplicacaoDadoLista)));
    }

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
        string message = $"Confirma a atualização do registro?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.UpdateConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdateConfirmationDialog>("Atualizar registro", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var tipoDadosListasId = _tiposDadosListas.Where(tipo => tipo.Tid_descri == tipoDadosListasSelected).Select(tipo => tipo.Id);

            UpdateDadosListasRequest.Dal_usualt = 1;
            UpdateDadosListasRequest.Dal_datalt = DateTime.Now;
            UpdateDadosListasRequest.Dal_usubdd = "DalDialog";
            UpdateDadosListasRequest.Dal_tid_descri = tipoDadosListasSelected;
            UpdateDadosListasRequest.Dal_tid_identi = tipoDadosListasId.FirstOrDefault();
            UpdateDadosListasRequest.Dal_aplicacao = aplicacaoSelected;

            var response = await _dadosListasServices.UpdateDadosListasAsync(UpdateDadosListasRequest);
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

    void Cancel() => MudDialog.Cancel();
}
