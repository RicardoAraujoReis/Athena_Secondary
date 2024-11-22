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

public class GetAtendimentoPlantaoHandlerByStatus : IRequestHandler<GetAtendimentoPlantaoByStatus, ResponseWrapper<List<AtendimentoPlantaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetAtendimentoPlantaoHandlerByStatus(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }    

    public async Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> Handle(GetAtendimentoPlantaoByStatus request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = _unitOfWork.ReadDataFor<AtendimentoPlantao>()
            .Entities
            .Where(atendimentoPlantao => atendimentoPlantao.Atd_status == request.AtendimentoByStatus)
            .FirstOrDefault();

        if (atendimentoPlantaoToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<AtendimentoPlantaoResponse>>().
                Success(data: atendimentoPlantaoToFind.
                Adapt<List<AtendimentoPlantaoResponse>>()));
        }

        return await Task.
            FromResult(new ResponseWrapper<List<AtendimentoPlantaoResponse>>().
            Failed("Registro não encontrado"));
    }
}