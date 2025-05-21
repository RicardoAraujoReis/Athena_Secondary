using Common.Responses.PainelGeral;
using Common.Wrapper;

namespace Athena.Web.Services;

public interface IPainelGeralBigNumbersServices
{
    Task<ResponseWrapper<List<PainelGeralBigNumbersResponse>>> GetPainelGeralBigNumbersCurrentAsync();
    Task<ResponseWrapper<List<PainelGeralBigNumbersResponse>>> GetPainelGeralBigNumbersAllAsync();
}
