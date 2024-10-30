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

public class GetTipoDadosListasHandlerAll : IRequestHandler<GetTipoDadosListasAll, ResponseWrapper<List<TipoDadosListasResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetTipoDadosListasHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<TipoDadosListasResponse>>> Handle(GetTipoDadosListasAll request, CancellationToken cancellationToken)
    {
        var tipoDadosListasToFind = await _unitOfWork.ReadDataFor<TipoDadosListas>().GetAllAsync();

        if (tipoDadosListasToFind.Count > 0)
        {
            return new ResponseWrapper<List<TipoDadosListasResponse>>().Success(tipoDadosListasToFind.Adapt<List<TipoDadosListasResponse>>());
        }
        return new ResponseWrapper<List<TipoDadosListasResponse>>().Failed("Não foram encontrados registros para a consulta realizada.");
    }
}
