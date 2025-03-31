using Athena.Web.Pages.Shared;
using Athena.Web.Validators.LinhaNegocioValidators;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.LinhaNegocio;

public partial class UpdateLinhaNegocioDialog
{
    [Parameter]
    public UpdateLinhaNegocio UpdateLinhaNegocioRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdateLinhaNegocioValidator _validator = new();

    private List<DadosListasResponse> _dadosListas = new List<DadosListasResponse>();
    private List<string> nomeDadosListasStatus = null;
    private string dadoListaStatusSelected = null;

    protected override async Task OnInitializedAsync()
    {
        var requestDadosListas = await _dadosListasServices.GetDadosListasAllAsync();
        if (requestDadosListas.IsSuccessful)
        {
            _dadosListas = requestDadosListas.Data;
        }
        else
        {
            _snackbar.Add(requestDadosListas.Messages, Severity.Error);
            MudDialog.Close();
        }

        if(UpdateLinhaNegocioRequest.Lhn_ativo == "S")
        {
            dadoListaStatusSelected = "SIM";
        }
        else
        {
            dadoListaStatusSelected = "NAO";
        }

        nomeDadosListasStatus = _dadosListas.Where(dados => dados.Dal_tid_descri == "REGISTRO ATIVO").Select(dados => dados.Dal_valor).ToList();        
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
        string message = $"Confirma a atualização da Linha de Negócio?";

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

        var dialog = _dialogService.Show<UpdateConfirmationDialog>("Atualizar a Linha de Negócio", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            UpdateLinhaNegocioRequest.Lhn_usualt = 1;
            UpdateLinhaNegocioRequest.Lhn_datalt = DateTime.Now;
            UpdateLinhaNegocioRequest.Lhn_usubdd = "LhnDialog";

            if (dadoListaStatusSelected == "SIM")
            {
                UpdateLinhaNegocioRequest.Lhn_ativo = "S";
            }
            else
            {
                UpdateLinhaNegocioRequest.Lhn_ativo = "N";
            }

            var response = await _linhaNegocioServices.UpdateLinhaNegocioAsync(UpdateLinhaNegocioRequest);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var messages in response.Messages)
                {
                    _snackbar.Add(messages.ToString(), Severity.Error);
                }
            }
        }
    }

    void Cancel() => MudDialog.Cancel();
}
