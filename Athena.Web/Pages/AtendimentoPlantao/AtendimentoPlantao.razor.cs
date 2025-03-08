using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.AtendimentoPlantao;

public partial class AtendimentoPlantao
{
    private List<AtendimentoPlantaoResponse> _atendimentosPlantao { get; set; } = new List<AtendimentoPlantaoResponse>();

    private bool _loading = true;    
    private string dataAlteracao = "---";

    protected override async Task OnInitializedAsync()
    {
        await LoadAtendimentosAsync();
    }

    private async Task LoadAtendimentosAsync()
    {
        var response = await _atendimentoPlantaoServices.GetAtendimentoPlantaoAllAsync();

        if (response.IsSuccessful)
        {
            _atendimentosPlantao = response.Data;
        }
        else
        {
            _snackbar.Add(response.Messages, Severity.Error);
        }
        _loading = false;
    }

    private async Task UpdateAtendimentoPlantaoAsync(int id)
    {

    }
}
