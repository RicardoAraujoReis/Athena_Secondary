using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface IDadosListasServices
{
    Task<ResponseWrapper<int>> CreateDadosListasAsync(CreateDadosListas createDadosListas);
    Task<ResponseWrapper<int>> UpdateDadosListasAsync(UpdateDadosListas updateDadosListas);
    Task<ResponseWrapper<int>> DeleteDadosListasAsync(int id);
    Task<ResponseWrapper<DadosListasResponse>> GetDadosListasByIdAsync(int id);
    Task<ResponseWrapper<List<DadosListasResponse>>> GetDadosListasAllAsync();
}
