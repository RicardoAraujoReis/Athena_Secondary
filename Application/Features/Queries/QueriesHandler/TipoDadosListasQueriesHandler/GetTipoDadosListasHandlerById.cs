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

namespace Application.Features.Queries.QueriesHandler.TipoDadosListasQueriesHandler;

public class GetTipoDadosListasHandlerById : IRequestHandler<GetTipoDadosListasById, ResponseWrapper<TipoDadosListasResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetTipoDadosListasHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<TipoDadosListasResponse>> Handle(GetTipoDadosListasById request, CancellationToken cancellationToken)
    {
        var tipoDadosListasToFind = await _unitOfWork.ReadDataFor<TipoDadosListas>().GetByIdAsync(request.Tid_identi);

        if (tipoDadosListasToFind is not null)
        {
            return new ResponseWrapper<TipoDadosListasResponse>().Success(tipoDadosListasToFind.Adapt<TipoDadosListasResponse>());
        }
        return new ResponseWrapper<TipoDadosListasResponse>().Failed("Registro não encontrado");
    }
}
