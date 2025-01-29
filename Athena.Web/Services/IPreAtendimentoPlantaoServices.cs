using Common.Requests;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface IPreAtendimentoPlantaoServices
{
    Task<ResponseWrapper<int>> CreatePreAtendimentoPlantaoAsync(CreatePreAtendimentoPlantao createPreAtendimentoPlantao);
    Task<ResponseWrapper<int>> UpdatePreAtendimentoPlantaoAsync(UpdatePreAtendimentoPlantao updatePreAtendimentoPlantao);
    Task<ResponseWrapper<int>> DeletePreAtendimentoPlantaoAsync(int id);
    Task<ResponseWrapper<PreAtendimentoPlantaoResponse>> GetPreAtendimentoPlantaoByIdAsync(int id);
    Task<ResponseWrapper<List<PreAtendimentoPlantaoResponse>>> GetPreAtendimentoPlantaoAllAsync();
}
