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

    private async Task UpdateAtendimentoPlantaoAsync(int atendimentoPlantaoId)
    {        
        var atendimentoToUpdate = _atendimentosPlantao.FirstOrDefault(atendimento => atendimento.Id == atendimentoPlantaoId);

        if(atendimentoToUpdate != null)
        {
            if(atendimentoToUpdate.Atd_status == "FINALIZADO")
            {
                _snackbar.Add("Registro não pode ser alterado", Severity.Info);
            }
            else
            {
                var parameters = new DialogParameters();

                parameters.Add(nameof(UpdateAtendimentoPlantaoDialog.UpdateAtendimentoPlantaoRequest), new UpdateAtendimentoPlantao
                {
                    Id = atendimentoToUpdate.Id,
                    Atd_ptd_identi = atendimentoToUpdate.Atd_ptd_identi,
                    Atd_titulo = atendimentoToUpdate.Atd_titulo,
                    Atd_cli_identi = atendimentoToUpdate.Atd_cli_identi,
                    Atd_tipatd = atendimentoToUpdate.Atd_tipatd,
                    Atd_resumo = atendimentoToUpdate.Atd_resumo,
                    Atd_respn2 = atendimentoToUpdate.Atd_respn2,
                    Atd_crijir = atendimentoToUpdate.Atd_crijir,
                    Atd_issue = atendimentoToUpdate.Atd_issue,
                    Atd_critic = atendimentoToUpdate.Atd_critic,
                    Atd_resplt = atendimentoToUpdate.Atd_resplt,
                    Atd_ren1hm = atendimentoToUpdate.Atd_ren1hm,
                    Atd_resn1 = atendimentoToUpdate.Atd_resn1,
                    Atd_evoln1 = atendimentoToUpdate.Atd_evoln1,
                    Atd_jusevo = atendimentoToUpdate.Atd_jusevo,
                    Atd_usubdd = atendimentoToUpdate.Atd_usubdd,
                    Atd_datatd = atendimentoToUpdate.Atd_datatd,
                    Atd_nomal2 = atendimentoToUpdate.Atd_nomal2,
                    Atd_nomal1 = atendimentoToUpdate.Atd_nomal1,
                    Atd_status = atendimentoToUpdate.Atd_status,
                    Atd_catnv1 = atendimentoToUpdate.Atd_catnv1,
                    Atd_catnv2 = atendimentoToUpdate.Atd_catnv2,
                    Atd_catnv3 = atendimentoToUpdate.Atd_catnv3,
                    Atd_catnv4 = atendimentoToUpdate.Atd_catnv4,
                    Atd_usucri = atendimentoToUpdate.Atd_usucri,
                    Atd_usualt = atendimentoToUpdate.Atd_usualt,
                    Atd_datcri = atendimentoToUpdate.Atd_datcri,
                    Atd_datalt = atendimentoToUpdate.Atd_datalt,
                    Atd_linjir = atendimentoToUpdate.Atd_linjir,
                    Atd_verjir = atendimentoToUpdate.Atd_verjir,
                    Atd_jirarl = atendimentoToUpdate.Atd_jirarl
                });

                var options = new DialogOptions
                {
                    CloseButton = true,
                    MaxWidth = MaxWidth.ExtraLarge,
                    FullWidth = true,
                    BackdropClick = false
                };

                var dialog = _dialogService.Show<UpdateAtendimentoPlantaoDialog>("Editar Atendimento", parameters, options);

                var result = await dialog.Result;

                if (!result.Canceled)
                {
                    await LoadAtendimentosAsync();
                }
            }
        }
        else
        {
            _snackbar.Add("Registro não encontrado", Severity.Error);
        }        
    }

    private async Task ViewAtendimentoPlantaoAsync(int idAtendimentoToView)
    {
        var atendimentoToView = _atendimentosPlantao.FirstOrDefault(atendimento => atendimento.Id == idAtendimentoToView);

        if(atendimentoToView is not null)
        {
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
        else
        {
            _snackbar.Add("Registro não encontrado", Severity.Error);
        }        
    }
}
