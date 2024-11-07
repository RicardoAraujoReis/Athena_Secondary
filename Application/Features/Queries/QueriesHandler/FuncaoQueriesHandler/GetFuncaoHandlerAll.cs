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

namespace Application.Features.Queries.QueriesHandler.FuncaoQueriesHandler;

public class GetFuncaoHandlerAll : IRequestHandler<GetFuncaoAll, ResponseWrapper<List<FuncaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetFuncaoHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<FuncaoResponse>>> Handle(GetFuncaoAll request, CancellationToken cancellationToken)
    {
        var funcaoToFind = await _unitOfWork.ReadDataFor<Funcao>().GetAllAsync();

        if (funcaoToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<FuncaoResponse>>().
                Success(funcaoToFind.
                Adapt<List<FuncaoResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<FuncaoResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}