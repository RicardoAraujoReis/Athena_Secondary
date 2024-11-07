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
        var tipoDadosListasToFind = await _unitOfWork.ReadDataFor<TipoDadosListas>().GetByIdAsync(request.Id);

        if (tipoDadosListasToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<TipoDadosListasResponse>().
                Success(tipoDadosListasToFind.
                Adapt<TipoDadosListasResponse>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<TipoDadosListasResponse>().
                Failed("Registro não encontrado"));
    }
}