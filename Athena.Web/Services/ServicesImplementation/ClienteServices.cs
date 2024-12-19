using Athena.Web.Endpoints;
using Athena.Web.Extensions;
using common.Requests;
using Common.Responses;
using Common.Wrapper;
using System.Net.Http.Json;

namespace Athena.Web.Services.ServicesImplementation;

public class ClienteServices : IClienteServices
{
    private readonly HttpClient _httpClient;

    public ClienteServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseWrapper<int>> CreateClienteAsync(CreateCliente createCliente)
    {
        var response = await _httpClient.PostAsJsonAsync(ClienteEndpoints.Create, createCliente);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<int>> DeleteClienteAsync(int id)
    {
        var endpoint = ClienteEndpoints.BuildEndpoints(ClienteEndpoints.Delete, id);
        var response = await _httpClient.DeleteAsync(endpoint);        
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<ClienteResponse>>> GetClienteAllAsync()
    {
        var response = await _httpClient.GetAsync(ClienteEndpoints.GetAll);
        return await response.ToResponse<List<ClienteResponse>>();
    }

    public async Task<ResponseWrapper<ClienteResponse>> GetClienteByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{ClienteEndpoints.GetById}/{id}");
        return await response.ToResponse<ClienteResponse>();
    }

    public Task<ResponseWrapper<List<ClienteResponse>>> GetClienteByParametersAsync(int? id, string status)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseWrapper<List<ClienteResponse>>> GetClienteByStatusAsync(string status)
    {        
        var response = await _httpClient.GetAsync($"{ClienteEndpoints.GetByStatus}/{status}");
        return await response.ToResponse<List<ClienteResponse>>();
    }

    public async Task<ResponseWrapper<int>> UpdateClienteAsync(UpdateCliente updateCliente)
    {
        var response = await _httpClient.PutAsJsonAsync(ClienteEndpoints.Update, updateCliente);
        return await response.ToResponse<int>();
    }

    public async Task<ResponseWrapper<List<ClienteResponse>>> GetClienteByDescriptionAsync(string description)
    {
        var response = await _httpClient.GetAsync($"{ClienteEndpoints.GetByDescription}/{description}");
        return await response.ToResponse<List<ClienteResponse>>();
    }
}
