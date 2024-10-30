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

public class GetFuncaoHandlerById : IRequestHandler<GetFuncaoById, ResponseWrapper<FuncaoResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetFuncaoHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<FuncaoResponse>> Handle(GetFuncaoById request, CancellationToken cancellationToken)
    {
        var funcaoToFind = await _unitOfWork.ReadDataFor<Funcao>().GetByIdAsync(request.Fnc_identi);

        if (funcaoToFind is not null)
        {
            return new ResponseWrapper<FuncaoResponse>().Success(funcaoToFind.Adapt<FuncaoResponse>());
        }
        return new ResponseWrapper<FuncaoResponse>().Failed("Registro não encontrado");
    }
}
