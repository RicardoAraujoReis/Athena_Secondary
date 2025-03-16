using Athena.Web.Validators.DadosListasValidators;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.DadosListas;

public partial class CreateDadosListasDialog
{
    [Parameter]
    public CreateDadosListas CreateDadosListasRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private DadosListasValidator _validator = new();

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

        listaAplicacao = new List<string>(Enum.GetNames(typeof(ListaAplicacaoDadoLista)));
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

        CreateDadosListasRequest.Dal_usucri = 1;
        CreateDadosListasRequest.Dal_usualt = null;
        CreateDadosListasRequest.Dal_datcri = DateTime.Now;
        CreateDadosListasRequest.Dal_datalt = null;
        CreateDadosListasRequest.Dal_usubdd = "DalDialog";
        CreateDadosListasRequest.Dal_tid_descri = tipoDadosListasSelected;
        CreateDadosListasRequest.Dal_valor = CreateDadosListasRequest.Dal_valor.ToUpper();
        CreateDadosListasRequest.Dal_tid_identi = tipoDadosListasId.FirstOrDefault();
        CreateDadosListasRequest.Dal_aplicacao = aplicacaoSelected;

        var response = await _dadosListasServices.CreateDadosListasAsync(CreateDadosListasRequest);
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
