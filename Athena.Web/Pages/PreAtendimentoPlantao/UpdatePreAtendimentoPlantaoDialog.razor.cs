using Athena.Web.Validators.CategoriaAtendimentoValidators;
using Athena.Web.Validators.PreAtendimentoPlantaoValidators;
using Common.Requests;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.PreAtendimentoPlantao;

public partial class UpdatePreAtendimentoPlantaoDialog
{
    [Parameter]
    public UpdatePreAtendimentoPlantao UpdatePreAtendimentoPlantaoRequest { get; set; } = new();

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    MudForm _form = default;

    private UpdatePreAtendimentoPlantaoValidator _validator = new();
}
