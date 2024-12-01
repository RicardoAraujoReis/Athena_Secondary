using Common.Responses;
using MudBlazor;

namespace Athena.Web.Pages.Cadastros.LinhaNegocio;

public partial class LinhaNegocio
{
    public List<LinhaNegocioResponse> linhaNegocios { get; set; } = new List<LinhaNegocioResponse>();
    private bool _loading = true;

    protected override async Task OnInitializedAsync()
    {
        var response = await _linhaNegocioServices.GetLinhaNegocioAllAsync();
        if (response.IsSuccessful)
        {
            linhaNegocios = response.Data.ToList();
            //_snackbar.Add("Teste");
        }
        else
        {
            foreach (var message in response.Messages)
            {
                _snackbar.Add(message.ToString(), Severity.Error);
            }            
        }
        _loading = false;
    }

    public async void CreateLinhaNegocioAsync()
    {
        await Console.Out.WriteLineAsync("inserir Linha de Negocio");
    }
}
