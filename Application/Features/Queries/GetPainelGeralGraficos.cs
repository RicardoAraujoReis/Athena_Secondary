using Common.Responses.PainelGeral;
using Common.Wrapper;
using MediatR;

namespace Application.Features.Queries;

public class GetPainelGeralGraficosAll : IRequest<ResponseWrapper<List<PainelGeralGraficosResponse>>>
{

}