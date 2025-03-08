using Common.Requests;
using Common.Requests.Searchs;
using Common.Responses;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface IAtendimentoPlantaoServices
{
    Task<ResponseWrapper<int>> CreateAtendimentoPlantaoAsync(CreateAtendimentoPlantao createAtendimentoPlantao);
    Task<ResponseWrapper<int>> UpdateAtendimentoPlantaoAsync(UpdateAtendimentoPlantao updateAtendimentoPlantao);
    Task<ResponseWrapper<int>> DeleteAtendimentoPlantaoAsync(int id);
    Task<ResponseWrapper<AtendimentoPlantaoResponse>> GetAtendimentoPlantaoByIdAsync(int id);
    Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> GetAtendimentoPlantaoAllAsync();
    //Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> GetAtendimentoPlantaoByParametersAsync(SearchAtendimentoPlantaoByParameters consulta);
}
