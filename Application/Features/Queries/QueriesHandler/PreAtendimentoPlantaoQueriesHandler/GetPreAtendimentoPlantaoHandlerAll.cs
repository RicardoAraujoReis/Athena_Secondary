using Athena.Models;
using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.QueriesHandler.PrePreAtendimentoPlantaoQueriesHandler;

public class GetPreAtendimentoPlantaoHandlerAll : IRequestHandler<GetPreAtendimentoPlantaoAll, ResponseWrapper<List<PreAtendimentoPlantaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetPreAtendimentoPlantaoHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<PreAtendimentoPlantaoResponse>>> Handle(GetPreAtendimentoPlantaoAll request, CancellationToken cancellationToken)
    {
        var preAtendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().GetAllAsync();

        if (preAtendimentoPlantaoToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<PreAtendimentoPlantaoResponse>>().
                Success(preAtendimentoPlantaoToFind.
                Adapt<List<PreAtendimentoPlantaoResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<PreAtendimentoPlantaoResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}