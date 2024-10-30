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

public class GetAtendimentoPlantaoHandlerById : IRequestHandler<GetAtendimentoPlantaoById, ResponseWrapper<AtendimentoPlantaoResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetAtendimentoPlantaoHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<AtendimentoPlantaoResponse>> Handle(GetAtendimentoPlantaoById request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<AtendimentoPlantao>().GetByIdAsync(request.Atd_identi);

        if (atendimentoPlantaoToFind is not null)
        {
            return new ResponseWrapper<AtendimentoPlantaoResponse>().Success(atendimentoPlantaoToFind.Adapt<AtendimentoPlantaoResponse>());
        }
        return new ResponseWrapper<AtendimentoPlantaoResponse>().Failed("Registro não encontrado");
    }
}
