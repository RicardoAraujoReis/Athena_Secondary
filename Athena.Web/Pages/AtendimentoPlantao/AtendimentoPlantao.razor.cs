using Athena.Web.Pages.PreAtendimentoPlantao;
using Common.Requests;
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

    private async Task ViewAtendimentoPlantaoAsync(int idAtendimentoToView)
    {
        var atendimentoToView = _atendimentosPlantao.FirstOrDefault(atendimento => atendimento.Id == idAtendimentoToView);

        var parameters = new DialogParameters();

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            BackdropClick = false
        };

        parameters.Add(nameof(ViewAtendimentoPlantaoDialog.ViewAtendimentoPlantao), new ViewAtendimentoPlantao
        {            
            Id = atendimentoToView.Id,
            Atd_ptd_identi = atendimentoToView.Atd_ptd_identi,
            Atd_titulo = atendimentoToView.Atd_titulo,
            Atd_cli_identi = atendimentoToView.Atd_cli_identi,
            Atd_tipatd = atendimentoToView.Atd_tipatd,
            Atd_resumo = atendimentoToView.Atd_resumo,
            Atd_respn2 = atendimentoToView.Atd_respn2,
            Atd_crijir = atendimentoToView.Atd_crijir,
            Atd_issue = atendimentoToView.Atd_issue,
            Atd_critic = atendimentoToView.Atd_critic,
            Atd_resplt = atendimentoToView.Atd_resplt,
            Atd_ren1hm = atendimentoToView.Atd_ren1hm,
            Atd_resn1 = atendimentoToView.Atd_resn1,
            Atd_evoln1 = atendimentoToView.Atd_evoln1,
            Atd_jusevo = atendimentoToView.Atd_jusevo,
            Atd_usubdd = atendimentoToView.Atd_usubdd,
            Atd_datatd = atendimentoToView.Atd_datatd,
            Atd_nomal2 = atendimentoToView.Atd_nomal2,
            Atd_nomal1 = atendimentoToView.Atd_nomal1,
            Atd_status = atendimentoToView.Atd_status,
            Atd_catnv1 = atendimentoToView.Atd_catnv1,
            Atd_catnv2 = atendimentoToView.Atd_catnv2,
            Atd_catnv3 = atendimentoToView.Atd_catnv3,
            Atd_catnv4 = atendimentoToView.Atd_catnv4,
            Atd_usucri = atendimentoToView.Atd_usucri,
            Atd_usualt = atendimentoToView.Atd_usualt,
            Atd_datcri = atendimentoToView.Atd_datcri,
            Atd_datalt = atendimentoToView.Atd_datalt,
            Atd_linjir = atendimentoToView.Atd_linjir,
            Atd_verjir = atendimentoToView.Atd_verjir,
            Atd_jirarl = atendimentoToView.Atd_jirarl
        });

        var dialog = _dialogService.Show<ViewAtendimentoPlantaoDialog>("Visualizar Atendimento", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            await LoadAtendimentosAsync();
        }
    }
}
