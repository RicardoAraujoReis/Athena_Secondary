using Common.Responses.PainelGeral;
using Common.Wrapper;
using MediatR;

namespace Application.Features.Queries;


public class GetPainelGeralBigNumbersCurrent : IRequest<ResponseWrapper<List<PainelGeralBigNumbersResponse>>>
{

}

public class GetPainelGeralBigNumbersAll : IRequest<ResponseWrapper<List<PainelGeralBigNumbersResponse>>>
{

}