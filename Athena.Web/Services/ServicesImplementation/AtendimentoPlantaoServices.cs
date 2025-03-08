using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Requests.Searchs;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class AtendimentoPlantaoServices : IAtendimentoPlantaoServices
{
    private readonly HttpClient _httpClient;

    public AtendimentoPlantaoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateAtendimentoPlantaoAsync(CreateAtendimentoPlantao createAtendimentoPlantao)
    {
        var response = await _httpClient.PostAsJsonAsync(AtendimentoPlantaoEndpoints.Create, createAtendimentoPlantao);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteAtendimentoPlantaoAsync(int id)
    {
        var endpoint = AtendimentoPlantaoEndpoints.BuildEndpoints(AtendimentoPlantaoEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> GetAtendimentoPlantaoAllAsync()
    {
        var response = await _httpClient.GetAsync(AtendimentoPlantaoEndpoints.GetAll);
        return await response.ToResponse<List<AtendimentoPlantaoResponse>>();
    }

    public async Task<ResponseWrapper<AtendimentoPlantaoResponse>> GetAtendimentoPlantaoByIdAsync(int id)
    {
        var endpoint = AtendimentoPlantaoEndpoints.BuildEndpoints(AtendimentoPlantaoEndpoints.GetById, id);
        var response = await _httpClient.GetAsync(endpoint);
        return await response.ToResponse<AtendimentoPlantaoResponse>();
    }

    public async Task<ResponseWrapper<int>> UpdateAtendimentoPlantaoAsync(UpdateAtendimentoPlantao updateAtendimentoPlantao)
    {
        var response = await _httpClient.PutAsJsonAsync(AtendimentoPlantaoEndpoints.Update, updateAtendimentoPlantao);
        return await response.ToResponse<int>();
    }

    /*
    public async Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> GetAtendimentoPlantaoByParametersAsync(SearchAtendimentoPlantaoByParameters consulta)
    {
        var response = await _httpClient.PostAsJsonAsync(AtendimentoPlantaoEndpoints.GetByParameters, consulta);
        return await response.ToResponse<List<AtendimentoPlantaoResponse>>();
    }
    */
}
