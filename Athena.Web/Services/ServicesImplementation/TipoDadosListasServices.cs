using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class TipoDadosListasServices : ITipoDadosListasServices
{
    private readonly HttpClient _httpClient;

    public TipoDadosListasServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateTipoDadosListasAsync(CreateTipoDadosListas createTipoDadosListas)
    {
        var response = await _httpClient.PostAsJsonAsync(TipoDadosListasEndpoints.Create, createTipoDadosListas);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteTipoDadosListasAsync(int id)
    {
        var endpoint = TipoDadosListasEndpoints.BuildEndpoints(TipoDadosListasEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<TipoDadosListasResponse>>> GetTipoDadosListasAllAsync()
    {
        var response = await _httpClient.GetAsync(TipoDadosListasEndpoints.GetAll);
        return await response.ToResponse<List<TipoDadosListasResponse>>();
    }

    public async Task<ResponseWrapper<TipoDadosListasResponse>> GetTipoDadosListasByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{TipoDadosListasEndpoints.GetById}/{id}");
        return await response.ToResponse<TipoDadosListasResponse>();
    }   

    public async Task<ResponseWrapper<int>> UpdateTipoDadosListasAsync(UpdateTipoDadosListas updateTipoDadosListas)
    {
        var response = await _httpClient.PutAsJsonAsync(TipoDadosListasEndpoints.Update, updateTipoDadosListas);
        return await response.ToResponse<int>();
    }
}
