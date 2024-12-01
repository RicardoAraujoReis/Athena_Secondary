using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services
{
    public interface ILinhaNegocioServices
    {
        Task<ResponseWrapper<int>> CreateLinhaNegocioAsync(CreateLinhaNegocio createLinhaNegocio);
        Task<ResponseWrapper<int>> UpdateLinhaNegocioAsync(UpdateLinhaNegocio updateLinhaNegocio);
        Task<ResponseWrapper<int>> DeleteLinhaNegocioAsync(int id);
        Task<ResponseWrapper<LinhaNegocioResponse>> GetLinhaNegocioByIdAsync(int id);
        Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioByStatusAsync(string status);
        Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioByParametersAsync(int? id, string status);
        Task<ResponseWrapper<List<LinhaNegocioResponse>>> GetLinhaNegocioAllAsync();
    }
}
