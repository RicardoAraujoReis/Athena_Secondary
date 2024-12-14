using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class LinhaNegocioServices : ILinhaNegocioServices
{
    private readonly HttpClient _httpClient;

    public LinhaNegocioServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateLinhaNegocioAsync(CreateLinhaNegocio createLinhaNegocio)
    {
        var response = await _httpClient.PostAsJsonAsync(LinhaNegocioEndpoints.Create, createLinhaNegocio);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteLinhaNegocioAsync(int id)
    {
        var endpoint = LinhaNegocioEndpoints.BuildEndpoints(LinhaNegocioEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);        
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioAllAsync()
    {
        var response = await _httpClient.GetAsync(LinhaNegocioEndpoints.GetAll);
        return await response.ToResponse<List<LinhaNegocioResponse>>();
    }

    public async Task<ResponseWrapper<LinhaNegocioResponse>> GetLinhaNegocioByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{LinhaNegocioEndpoints.GetById}/{id}");
        return await response.ToResponse<LinhaNegocioResponse>();
    }

    public Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioByParametersAsync(int? id, string status)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioByStatusAsync(string status)
    {        
        var response = await _httpClient.GetAsync($"{LinhaNegocioEndpoints.GetByStatus}/{status}");
        return await response.ToResponse<List<LinhaNegocioResponse>>();
    }

    public async Task<ResponseWrapper<int>> UpdateLinhaNegocioAsync(UpdateLinhaNegocio updateLinhaNegocio)
    {
        var response = await _httpClient.PutAsJsonAsync(LinhaNegocioEndpoints.Update, updateLinhaNegocio);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioByDescriptionAsync(string description)
    {
        var response = await _httpClient.GetAsync($"{LinhaNegocioEndpoints.GetByDescription}/{description}");
        return await response.ToResponse<List<LinhaNegocioResponse>>();
    }
}
