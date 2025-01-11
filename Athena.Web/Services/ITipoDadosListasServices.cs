using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface ITipoDadosListasServices
{
    Task<ResponseWrapper<int>> CreateTipoDadosListasAsync(CreateTipoDadosListas createTipoDadosListas);
    Task<ResponseWrapper<int>> UpdateTipoDadosListasAsync(UpdateTipoDadosListas updateTipoDadosListas);
    Task<ResponseWrapper<int>> DeleteTipoDadosListasAsync(int id);
    Task<ResponseWrapper<TipoDadosListasResponse>> GetTipoDadosListasByIdAsync(int id);
    Task<ResponseWrapper<List<TipoDadosListasResponse>>> GetTipoDadosListasAllAsync();
}
