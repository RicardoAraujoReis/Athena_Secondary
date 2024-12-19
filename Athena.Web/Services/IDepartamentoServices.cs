using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services
{
    public interface IDepartamentoServices
    {
        Task<ResponseWrapper<int>> CreateDepartamentoAsync(CreateDepartamento createDepartamento);
        Task<ResponseWrapper<int>> UpdateDepartamentoAsync(UpdateDepartamento updateDepartamento);
        Task<ResponseWrapper<int>> DeleteDepartamentoAsync(int id);
        Task<ResponseWrapper<DepartamentoResponse>> GetDepartamentoByIdAsync(int id);
        Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoByStatusAsync(string status);
        Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoByParametersAsync(int? id, string status);
        Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoAllAsync();
        Task<ResponseWrapper<List<DepartamentoResponse>>> GetDepartamentoByDescriptionAsync(string description);
    }
}
