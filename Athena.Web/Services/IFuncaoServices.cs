using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services
{
    public interface IFuncaoServices
    {
        Task<ResponseWrapper<int>> CreateFuncaoAsync(CreateFuncao createFuncao);
        Task<ResponseWrapper<int>> UpdateFuncaoAsync(UpdateFuncao updateFuncao);
        Task<ResponseWrapper<int>> DeleteFuncaoAsync(int id);
        Task<ResponseWrapper<FuncaoResponse>> GetFuncaoByIdAsync(int id);
        Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoByStatusAsync(string status);
        Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoByParametersAsync(int? id, string status);
        Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoAllAsync();
        Task<ResponseWrapper<List<FuncaoResponse>>> GetFuncaoByDescriptionAsync(string description);
    }
}
