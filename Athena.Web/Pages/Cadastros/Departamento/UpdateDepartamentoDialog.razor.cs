using Athena.Web.Validators.DepartamentoValidators;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.Departamento;

public partial class UpdateDepartamentoDialog
{
    [Parameter]
    public UpdateDepartamento UpdateDepartamentoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateDepartamentoValidator _validator = new();

    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();

    private List<string> nomeDadosListasRegistroAtivo = null;
    private string dadoListaRegistroAtivoSelected = null;

    protected override async Task OnInitializedAsync()
    {       
        if (UpdateDepartamentoRequest.Dpt_ativo == "S")
        {
            dadoListaRegistroAtivoSelected = "SIM";
        }
        else
        {
            dadoListaRegistroAtivoSelected = "NAO";
        }

        var requestDadosListas = await _dadosListasServices.GetDadosListasAllAsync();
        if (requestDadosListas.IsSuccessful)
        {
            _dadosListas = requestDadosListas.Data;
        }
        nomeDadosListasRegistroAtivo = _dadosListas.Where(dados => dados.Dal_tid_descri == "REGISTRO ATIVO").Select(dados => dados.Dal_valor).ToList();
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
        UpdateDepartamentoRequest.Dpt_usualt = 1;
        UpdateDepartamentoRequest.Dpt_datalt = DateTime.Now;
        UpdateDepartamentoRequest.Dpt_usubdd = "LhnDialog";
        UpdateDepartamentoRequest.Dpt_descri = UpdateDepartamentoRequest.Dpt_descri.ToUpper();

        if (!string.IsNullOrWhiteSpace(dadoListaRegistroAtivoSelected))
        {
            if (dadoListaRegistroAtivoSelected.Equals("NAO"))
            {
                UpdateDepartamentoRequest.Dpt_ativo = "N";
            }
            else
            {
                UpdateDepartamentoRequest.Dpt_ativo = "S";
            }
        }

        var response = await _departamentoServices.UpdateDepartamentoAsync(UpdateDepartamentoRequest);
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
