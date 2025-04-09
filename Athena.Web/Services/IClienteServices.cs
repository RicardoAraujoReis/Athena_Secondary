using common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface IClienteServices
{
    Task<ResponseWrapper<int>> CreateClienteAsync(CreateCliente createCliente);
    Task<ResponseWrapper<int>> UpdateClienteAsync(UpdateCliente updateCliente);
    Task<ResponseWrapper<int>> DeleteClienteAsync(int id);
    Task<ResponseWrapper<ClienteResponse>> GetClienteByIdAsync(int id);
    Task<ResponseWrapper<List<ClienteResponse>>> GetClienteByStatusAsync(string status);
    Task<ResponseWrapper<List<ClienteResponse>>> GetClienteByParametersAsync(int? id, string status);
    Task<ResponseWrapper<List<ClienteResponse>>> GetClienteAllAsync();
    Task<ResponseWrapper<List<ClienteResponse>>> GetClienteByDescriptionAsync(string description);
}
