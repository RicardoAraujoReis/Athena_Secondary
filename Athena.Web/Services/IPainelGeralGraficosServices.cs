using Common.Responses.PainelGeral;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface IPainelGeralGraficosServices
{    
    Task<ResponseWrapper<List<PainelGeralGraficosResponse>>> GetPainelGeralGraficosAllAsync();
}
