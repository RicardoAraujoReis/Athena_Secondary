using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Responses.PainelGeral;
using Common.Wrapper;

namespace Athena.Web.Services.ServicesImplementation;

public class PainelGeralGraficosServices : IPainelGeralGraficosServices
{
    private readonly HttpClient _httpClient;

    public PainelGeralGraficosServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }    

    public async Task<ResponseWrapper<List<PainelGeralGraficosResponse>>> GetPainelGeralGraficosAllAsync()
    {
        var response = await _httpClient.GetAsync(PainelGeralGraficosEndpoints.GetAll);
        return await response.ToResponse<List<PainelGeralGraficosResponse>>();
    }
}
