using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class CategoriaAtendimentoServices : ICategoriaAtendimentoServices
{
    private readonly HttpClient _httpClient;

    public CategoriaAtendimentoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateCategoriaAtendimentoAsync(CreateCategoriaAtendimento createCategoriaAtendimento)
    {
        var response = await _httpClient.PostAsJsonAsync(CategoriaAtendimentoEndpoints.Create, createCategoriaAtendimento);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteCategoriaAtendimentoAsync(int id)
    {
        var endpoint = CategoriaAtendimentoEndpoints.BuildEndpoints(CategoriaAtendimentoEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);        
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoAllAsync()
    {
        var response = await _httpClient.GetAsync(CategoriaAtendimentoEndpoints.GetAll);
        return await response.ToResponse<List<CategoriaAtendimentoResponse>>();
    }

    public async Task<ResponseWrapper<CategoriaAtendimentoResponse>> GetCategoriaAtendimentoByIdAsync(int id)
    {
        var endpoint = CategoriaAtendimentoEndpoints.BuildEndpoints(CategoriaAtendimentoEndpoints.GetById, id);
        var response = await _httpClient.GetAsync(endpoint);
        //var response = await _httpClient.GetAsync($"{CategoriaAtendimentoEndpoints.GetById}/{id}");
        return await response.ToResponse<CategoriaAtendimentoResponse>();
    }

    public Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoByParametersAsync(int? id, string status)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoByStatusAsync(string status)
    {        
        var response = await _httpClient.GetAsync($"{CategoriaAtendimentoEndpoints.GetByStatus}/{status}");
        return await response.ToResponse<List<CategoriaAtendimentoResponse>>();
    }

    public async Task<ResponseWrapper<int>> UpdateCategoriaAtendimentoAsync(UpdateCategoriaAtendimento updateCategoriaAtendimento)
    {
        var response = await _httpClient.PutAsJsonAsync(CategoriaAtendimentoEndpoints.Update, updateCategoriaAtendimento);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoByDescriptionAsync(string description)
    {
        var response = await _httpClient.GetAsync($"{CategoriaAtendimentoEndpoints.GetByDescription}/{description}");
        return await response.ToResponse<List<CategoriaAtendimentoResponse>>();
    }
}
