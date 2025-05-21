using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Responses.PainelGeral;
using Common.Wrapper;
using System.Net.Http;

namespace Athena.Web.Services.ServicesImplementation;

public class PainelGeralBigNumbersServices : IPainelGeralBigNumbersServices
{
    private readonly HttpClient _httpClient;

    public PainelGeralBigNumbersServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<List<PainelGeralBigNumbersResponse>>> GetPainelGeralBigNumbersCurrentAsync()
    {
        var response = await _httpClient.GetAsync(PainelGeralBigNumbersEndpoints.GetCurrent);
        return await response.ToResponse<List<PainelGeralBigNumbersResponse>>();
    }

    public async Task<ResponseWrapper<List<PainelGeralBigNumbersResponse>>> GetPainelGeralBigNumbersAllAsync()
    {
        var response = await _httpClient.GetAsync(PainelGeralBigNumbersEndpoints.GetAll);
        return await response.ToResponse<List<PainelGeralBigNumbersResponse>>();
    }
}
