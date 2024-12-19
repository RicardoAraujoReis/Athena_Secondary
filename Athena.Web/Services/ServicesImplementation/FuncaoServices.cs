using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class FuncaoServices : IFuncaoServices
{
    private readonly HttpClient _httpClient;

    public FuncaoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateFuncaoAsync(CreateFuncao createFuncao)
    {
        var response = await _httpClient.PostAsJsonAsync(FuncaoEndpoints.Create, createFuncao);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteFuncaoAsync(int id)
    {
        var endpoint = FuncaoEndpoints.BuildEndpoints(FuncaoEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);        
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoAllAsync()
    {
        var response = await _httpClient.GetAsync(FuncaoEndpoints.GetAll);
        return await response.ToResponse<List<FuncaoResponse>>();
    }

    public async Task<ResponseWrapper<FuncaoResponse>> GetFuncaoByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{FuncaoEndpoints.GetById}/{id}");
        return await response.ToResponse<FuncaoResponse>();
    }

    public Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoByParametersAsync(int? id, string status)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoByStatusAsync(string status)
    {        
        var response = await _httpClient.GetAsync($"{FuncaoEndpoints.GetByStatus}/{status}");
        return await response.ToResponse<List<FuncaoResponse>>();
    }

    public async Task<ResponseWrapper<int>> UpdateFuncaoAsync(UpdateFuncao updateFuncao)
    {
        var response = await _httpClient.PutAsJsonAsync(FuncaoEndpoints.Update, updateFuncao);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoByDescriptionAsync(string description)
    {
        var response = await _httpClient.GetAsync($"{FuncaoEndpoints.GetByDescription}/{description}");
        return await response.ToResponse<List<FuncaoResponse>>();
    }
}
