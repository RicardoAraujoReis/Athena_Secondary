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

namespace Application.Features.Queries.QueriesHandler.AtendimentoPlantaoQueriesHandler;

public class GetAtendimentoPlantaoHandlerAll : IRequestHandler<GetAtendimentoPlantaoAll, ResponseWrapper<List<AtendimentoPlantaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetAtendimentoPlantaoHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> Handle(GetAtendimentoPlantaoAll request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<AtendimentoPlantao>().GetAllAsync();

        if (atendimentoPlantaoToFind.Count > 0)
        {
            return new ResponseWrapper<List<AtendimentoPlantaoResponse>>().Success(atendimentoPlantaoToFind.Adapt<List<AtendimentoPlantaoResponse>>());
        }
        return new ResponseWrapper<List<AtendimentoPlantaoResponse>>().Failed("Não foram encontrados registros para a consulta realizada.");
    }
}
