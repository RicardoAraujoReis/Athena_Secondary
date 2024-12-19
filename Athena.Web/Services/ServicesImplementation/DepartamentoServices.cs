using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using Common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class DepartamentoServices : IDepartamentoServices
{
    private readonly HttpClient _httpClient;

    public DepartamentoServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateDepartamentoAsync(CreateDepartamento createDepartamento)
    {
        var response = await _httpClient.PostAsJsonAsync(DepartamentoEndpoints.Create, createDepartamento);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteDepartamentoAsync(int id)
    {
        var endpoint = DepartamentoEndpoints.BuildEndpoints(DepartamentoEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);        
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoAllAsync()
    {
        var response = await _httpClient.GetAsync(DepartamentoEndpoints.GetAll);
        return await response.ToResponse<List<DepartamentoResponse>>();
    }

    public async Task<ResponseWrapper<DepartamentoResponse>> GetDepartamentoByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{DepartamentoEndpoints.GetById}/{id}");
        return await response.ToResponse<DepartamentoResponse>();
    }

    public Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoByParametersAsync(int? id, string status)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoByStatusAsync(string status)
    {        
        var response = await _httpClient.GetAsync($"{DepartamentoEndpoints.GetByStatus}/{status}");
        return await response.ToResponse<List<DepartamentoResponse>>();
    }

    public async Task<ResponseWrapper<int>> UpdateDepartamentoAsync(UpdateDepartamento updateDepartamento)
    {
        var response = await _httpClient.PutAsJsonAsync(DepartamentoEndpoints.Update, updateDepartamento);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoByDescriptionAsync(string description)
    {
        var response = await _httpClient.GetAsync($"{DepartamentoEndpoints.GetByDescription}/{description}");
        return await response.ToResponse<List<DepartamentoResponse>>();
    }
}
