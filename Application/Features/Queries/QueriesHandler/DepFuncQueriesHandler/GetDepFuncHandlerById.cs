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

public class GetDepFuncHandlerById : IRequestHandler<GetDepFuncById, ResponseWrapper<DepFuncResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDepFuncHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<DepFuncResponse>> Handle(GetDepFuncById request, CancellationToken cancellationToken)
    {
        var depFuncToFind = await _unitOfWork.ReadDataFor<DepFunc>().GetByIdAsync(request.Dfc_identi);

        if (depFuncToFind is not null)
        {
            return new ResponseWrapper<DepFuncResponse>().Success(depFuncToFind.Adapt<DepFuncResponse>());
        }
        return new ResponseWrapper<DepFuncResponse>().Failed("Registro não encontrado");
    }
}
