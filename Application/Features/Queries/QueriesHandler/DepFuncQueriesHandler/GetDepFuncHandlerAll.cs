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

namespace Application.Features.Queries.QueriesHandler.DepFuncQueriesHandler;

public class GetDepFuncHandlerAll : IRequestHandler<GetDepFuncAll, ResponseWrapper<List<DepFuncResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDepFuncHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<DepFuncResponse>>> Handle(GetDepFuncAll request, CancellationToken cancellationToken)
    {
        var depFuncToFind = await _unitOfWork.ReadDataFor<DepFunc>().GetAllAsync();

        if (depFuncToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<DepFuncResponse>>().
                Success(depFuncToFind.
                Adapt<List<DepFuncResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<DepFuncResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}
