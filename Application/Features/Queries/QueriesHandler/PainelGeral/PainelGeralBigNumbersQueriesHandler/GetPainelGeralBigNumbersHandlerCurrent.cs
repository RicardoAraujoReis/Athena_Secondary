using Common.Wrapper;
using Mapster;
using MediatR;
using Models.PainelGeral;
using Common.Responses.PainelGeral;

namespace Application.Features.Queries.QueriesHandler.PainelGeral.PainelGeralBigNumbersQueriesHandler;

public class GetPainelGeralBigNumbersCurrentHandler : IRequestHandler<GetPainelGeralBigNumbersCurrent, ResponseWrapper<List<PainelGeralBigNumbersResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetPainelGeralBigNumbersCurrentHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<PainelGeralBigNumbersResponse>>> Handle(GetPainelGeralBigNumbersCurrent request, CancellationToken cancellationToken)
    {
        var bigNumbersValues = _unitOfWork.ReadDataFor<PainelGeralBigNumbers>().Entities
            .OrderByDescending(value => value.DataAtualizacao).FirstOrDefault();

        if (bigNumbersValues is not null)
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
