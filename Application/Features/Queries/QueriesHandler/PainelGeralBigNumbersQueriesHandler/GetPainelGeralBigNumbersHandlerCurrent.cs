using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using Athena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.QueriesHandler.PainelGeralBigNumbersQueriesHandler;

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
