using Common.Wrapper;
using Mapster;
using MediatR;
using Models.PainelGeral;
using Common.Responses.PainelGeral;

namespace Application.Features.Queries.QueriesHandler.PainelGeral.PainelGeralBigNumbersQueriesHandler;

public class GetPainelGeralBigNumbersAllHandler : IRequestHandler<GetPainelGeralBigNumbersAll, ResponseWrapper<List<PainelGeralBigNumbersResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetPainelGeralBigNumbersAllHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<PainelGeralBigNumbersResponse>>> Handle(GetPainelGeralBigNumbersAll request, CancellationToken cancellationToken)
    {
        var bigNumbersValues = await _unitOfWork.ReadDataFor<PainelGeralBigNumbers>().GetAllAsync();

        if (bigNumbersValues.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<PainelGeralBigNumbersResponse>>().
                Success(bigNumbersValues.
                Adapt<List<PainelGeralBigNumbersResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<PainelGeralBigNumbersResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}
