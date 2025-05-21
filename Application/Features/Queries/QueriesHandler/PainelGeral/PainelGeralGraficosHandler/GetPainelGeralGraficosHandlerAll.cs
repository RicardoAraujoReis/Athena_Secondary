using Common.Wrapper;
using Mapster;
using MediatR;
using Models.PainelGeral;
using Common.Responses.PainelGeral;
using Athena.Models;

namespace Application.Features.Queries.QueriesHandler.PainelGeral.PainelGeralBigNumbersQueriesHandler;

public class GetPainelGeralGraficosHandlerAll : IRequestHandler<GetPainelGeralGraficosAll, ResponseWrapper<List<PainelGeralGraficosResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetPainelGeralGraficosHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }    

    public async Task<ResponseWrapper<List<PainelGeralGraficosResponse>>> Handle(GetPainelGeralGraficosAll request, CancellationToken cancellationToken)
    {
        var graficosValues = await _unitOfWork.ReadDataFor<PainelGeralGraficos>().GetAllAsync();        

        if (graficosValues.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<PainelGeralGraficosResponse>>().
                Success(graficosValues.
                Adapt<List<PainelGeralGraficosResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<PainelGeralGraficosResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}
