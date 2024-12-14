using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Athena.Web.Pages.Shared;

public partial class DeleteConfirmationDialog
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public string MessageConfirmation { get; set; }

    void Agreed() => MudDialog.Close(DialogResult.Ok(true));
    
    void Cancel() => MudDialog.Cancel();
}
