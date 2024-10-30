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

namespace Application.Features.Queries.QueriesHandler.LinhaNegocioQueriesHandler;

public class GetLinhaNegocioHandlerAll : IRequestHandler<GetLinhaNegocioAll, ResponseWrapper<List<LinhaNegocioResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetLinhaNegocioHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<LinhaNegocioResponse>>> Handle(GetLinhaNegocioAll request, CancellationToken cancellationToken)
    {
        var linhaNegocioToFind = await _unitOfWork.ReadDataFor<LinhaNegocio>().GetAllAsync();

        if (linhaNegocioToFind.Count > 0)
        {
            return new ResponseWrapper<List<LinhaNegocioResponse>>().Success(linhaNegocioToFind.Adapt<List<LinhaNegocioResponse>>());
        }
        return new ResponseWrapper<List<LinhaNegocioResponse>>().Failed("Não foram encontrados registros para a consulta realizada.");
    }
}
