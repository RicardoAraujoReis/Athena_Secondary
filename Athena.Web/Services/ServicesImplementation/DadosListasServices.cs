using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class DadosListasServices : IDadosListasServices
{
    private readonly HttpClient _httpClient;

    public DadosListasServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateDadosListasAsync(CreateDadosListas createDadosListas)
    {
        var response = await _httpClient.PostAsJsonAsync(DadosListasEndpoints.Create, createDadosListas);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteDadosListasAsync(int id)
    {
        var endpoint = DadosListasEndpoints.BuildEndpoints(DadosListasEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<DadosListasResponse>>> GetDadosListasAllAsync()
    {
        var response = await _httpClient.GetAsync(DadosListasEndpoints.GetAll);
        return await response.ToResponse<List<DadosListasResponse>>();
    }

    public async Task<ResponseWrapper<DadosListasResponse>> GetDadosListasByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{DadosListasEndpoints.GetById}/{id}");
        return await response.ToResponse<DadosListasResponse>();
    }

    public async Task<ResponseWrapper<int>> UpdateDadosListasAsync(UpdateDadosListas updateDadosListas)
    {
        var response = await _httpClient.PutAsJsonAsync(DadosListasEndpoints.Update, updateDadosListas);
        return await response.ToResponse<int>();
    }
}
