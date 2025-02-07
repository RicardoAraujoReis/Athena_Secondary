using Athena.Web.Pages.Cadastros.TipoDadosListas;
using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class PreAtendimentoPlantao
{
    public List<PreAtendimentoPlantaoResponse> preAtendimentos { get; set; } = new List<PreAtendimentoPlantaoResponse>();
    private bool _loading = true;
    private string searchPreAtendimentos = null;
    private string dataAlteracao = "---";

    protected override async Task OnInitializedAsync()
    {
        await LoadPreAtendimentoPlantaoAsync();
    }

    private async Task LoadPreAtendimentoPlantaoAsync()
    {
        var response = await _preAtendimentoPlantaoServices.GetPreAtendimentoPlantaoAllAsync();
        if (response.IsSuccessful)
        {
            preAtendimentos = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);
        }
        _loading = false;
    }

    private async void CreatePreAtendimentoPlantaoAsync()
    {
        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<CreatePreAtendimentoPlantaoDialog>("Add Pré Atendimento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadPreAtendimentoPlantaoAsync();
        }
    }
}