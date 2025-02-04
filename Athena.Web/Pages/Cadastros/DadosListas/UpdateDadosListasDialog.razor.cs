using Athena.Web.Validators.DadosListasValidators;
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
        var tipoDadosListasId = _tiposDadosListas.Where(tipo => tipo.Tid_descri == tipoDadosListasSelected).Select(tipo => tipo.Id);

        UpdateDadosListasRequest.Dal_usualt = 1;
        UpdateDadosListasRequest.Dal_datalt = DateTime.Now;
        UpdateDadosListasRequest.Dal_usubdd = "DalDialog";        
        UpdateDadosListasRequest.Dal_tid_identi = tipoDadosListasId.FirstOrDefault();

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

    void Cancel() => MudDialog.Cancel();
}
