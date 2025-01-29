using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class PreAtendimentoPlantaoServices : IPreAtendimentoPlantaoServices
{
    private readonly HttpClient _httpClient;

    public PreAtendimentoPlantaoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreatePreAtendimentoPlantaoAsync(CreatePreAtendimentoPlantao createPreAtendimentoPlantao)
    {
        var response = await _httpClient.PostAsJsonAsync(PreAtendimentoPlantaoEndpoints.Create, createPreAtendimentoPlantao);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeletePreAtendimentoPlantaoAsync(int id)
    {
        var endpoint = PreAtendimentoPlantaoEndpoints.BuildEndpoints(PreAtendimentoPlantaoEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<PreAtendimentoPlantaoResponse>>> GetPreAtendimentoPlantaoAllAsync()
    {
        var response = await _httpClient.GetAsync(PreAtendimentoPlantaoEndpoints.GetAll);
        return await response.ToResponse<List<PreAtendimentoPlantaoResponse>>();
    }

    public async Task<ResponseWrapper<PreAtendimentoPlantaoResponse>> GetPreAtendimentoPlantaoByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseWrapper<int>> UpdatePreAtendimentoPlantaoAsync(UpdatePreAtendimentoPlantao updatePreAtendimentoPlantao)
    {
        var response = await _httpClient.PutAsJsonAsync(PreAtendimentoPlantaoEndpoints.Update, updatePreAtendimentoPlantao);
        return await response.ToResponse<int>();
    }
}
