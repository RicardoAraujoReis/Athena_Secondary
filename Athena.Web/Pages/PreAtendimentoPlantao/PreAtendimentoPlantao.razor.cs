using Athena.Web.Pages.Cadastros.CategoriaAtendimento;
using Athena.Web.Pages.Cadastros.TipoDadosListas;
using Athena.Web.Pages.Shared;
using Common.Requests;
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

    private async Task UpdatePreAtendimentoPlantaoAsync(int preAtendimentoPlantaoId)
    {
        var parameters = new DialogParameters();

        var preAtendimentoToUpdate = preAtendimentos.FirstOrDefault(preAtendimento => preAtendimento.Id == preAtendimentoPlantaoId);

        parameters.Add(nameof(UpdatePreAtendimentoPlantaoDialog.UpdatePreAtendimentoPlantaoRequest), new UpdatePreAtendimentoPlantao
        {
            Id = preAtendimentoPlantaoId,
            Ptd_datptd = preAtendimentoToUpdate.Ptd_datptd,
            Ptd_usu_identi = preAtendimentoToUpdate.Ptd_usu_identi,
            Ptd_cli_identi = preAtendimentoToUpdate.Ptd_cli_identi,
            Ptd_tipptd = preAtendimentoToUpdate.Ptd_tipptd,
            Ptd_critic = preAtendimentoToUpdate.Ptd_critic,
            Ptd_titulo = preAtendimentoToUpdate.Ptd_titulo,
            Ptd_resumo = preAtendimentoToUpdate.Ptd_resumo,
            Ptd_numcha = preAtendimentoToUpdate.Ptd_numcha,
            Ptd_jirarl = preAtendimentoToUpdate.Ptd_jirarl,
            Ptd_numjir = preAtendimentoToUpdate.Ptd_numjir,
            Ptd_diagn1 = preAtendimentoToUpdate.Ptd_diagn1,
            Ptd_status = preAtendimentoToUpdate.Ptd_status,
            Ptd_reton2 = preAtendimentoToUpdate.Ptd_reton2,
            Ptd_observ = preAtendimentoToUpdate.Ptd_observ,
            Ptd_nomal1 = preAtendimentoToUpdate.Ptd_nomal1,
            Ptd_numatd = preAtendimentoToUpdate.Ptd_numatd,
            Ptd_usubdd = preAtendimentoToUpdate.Ptd_usubdd,
            Ptd_datcri = preAtendimentoToUpdate.Ptd_datcri,
            Ptd_datalt = preAtendimentoToUpdate.Ptd_datalt,
            Ptd_usucri = preAtendimentoToUpdate.Ptd_usucri,
            Ptd_usualt = preAtendimentoToUpdate.Ptd_usualt,
            Ptd_linjir = preAtendimentoToUpdate.Ptd_linjir,
            Ptd_verjir = preAtendimentoToUpdate.Ptd_verjir
        });

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<UpdatePreAtendimentoPlantaoDialog>("Editar Pré Atendimento", parameters, options);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadPreAtendimentoPlantaoAsync();
        }
    }

    private async Task DeletePreAtendimentoPlantaoAsync(int idPtdToDConfirm)
    {
        string message = $"Confirma a deleção do Pré Atendimento {idPtdToDConfirm} ?";

        var parameters = new DialogParameters
        {
            { nameof(Shared.DeleteConfirmationDialog.MessageConfirmation), message },
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            BackdropClick = false
        };

        var dialog = _dialogService.Show<DeleteConfirmationDialog>("Deletar Pré Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var response = await _preAtendimentoPlantaoServices.DeletePreAtendimentoPlantaoAsync(idPtdToDConfirm);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages, Severity.Success);
                await LoadPreAtendimentoPlantaoAsync();
            }
            else
            {
                _snackbar.Add(response.Messages, Severity.Error);
            }
        }
    }
}