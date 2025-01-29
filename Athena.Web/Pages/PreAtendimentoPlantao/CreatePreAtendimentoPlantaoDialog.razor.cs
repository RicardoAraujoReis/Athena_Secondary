using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class CreatePreAtendimentoPlantaoDialog
{
    [Parameter]
    public CreatePreAtendimentoPlantao CreatePreAtendimentoPlantaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private PreAtendimentoPlantaoValidator _validator = new();

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
        CreatePreAtendimentoPlantaoRequest.Ptd_usucri = 1;
        CreatePreAtendimentoPlantaoRequest.Ptd_usualt = null;
        CreatePreAtendimentoPlantaoRequest.Ptd_datcri = DateTime.Now;
        CreatePreAtendimentoPlantaoRequest.Ptd_datalt = null;
        CreatePreAtendimentoPlantaoRequest.Ptd_usubdd = "PtdDialog";
        CreatePreAtendimentoPlantaoRequest.Ptd_usu_identi = 2; //DESENVOLVER RECURSO PARA RECUPERAR O USUÁRIO LOGADO

        var response = await _preAtendimentoPlantaoServices.CreatePreAtendimentoPlantaoAsync(CreatePreAtendimentoPlantaoRequest);
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
