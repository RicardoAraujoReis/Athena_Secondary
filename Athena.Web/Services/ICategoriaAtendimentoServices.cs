using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services
{
    public interface ICategoriaAtendimentoServices
    {
        Task<ResponseWrapper<int>> CreateCategoriaAtendimentoAsync(CreateCategoriaAtendimento createCategoriaAtendimento);
        Task<ResponseWrapper<int>> UpdateCategoriaAtendimentoAsync(UpdateCategoriaAtendimento updateCategoriaAtendimento);
        Task<ResponseWrapper<int>> DeleteCategoriaAtendimentoAsync(int id);
        Task<ResponseWrapper<CategoriaAtendimentoResponse>> GetCategoriaAtendimentoByIdAsync(int id);
        Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoByStatusAsync(string status);
        Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoByParametersAsync(int? id, string status);
        Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoAllAsync();
        Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> GetCategoriaAtendimentoByDescriptionAsync(string description);
    }
}
