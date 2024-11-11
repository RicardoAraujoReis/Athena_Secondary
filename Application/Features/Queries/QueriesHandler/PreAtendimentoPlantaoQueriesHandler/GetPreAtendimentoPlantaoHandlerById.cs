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

public class GetPreAtendimentoPlantaoHandlerById : IRequestHandler<GetPreAtendimentoPlantaoById, ResponseWrapper<PreAtendimentoPlantaoResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetPreAtendimentoPlantaoHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<PreAtendimentoPlantaoResponse>> Handle(GetPreAtendimentoPlantaoById request, CancellationToken cancellationToken)
    {
        var preAtendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().GetByIdAsync(request.Id);

        if (preAtendimentoPlantaoToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<PreAtendimentoPlantaoResponse>().
                Success(preAtendimentoPlantaoToFind.
                Adapt<PreAtendimentoPlantaoResponse>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<PreAtendimentoPlantaoResponse>().
                Failed("Registro não encontrado"));
    }
}