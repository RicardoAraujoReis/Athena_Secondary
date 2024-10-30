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

namespace Application.Features.Queries.QueriesHandler.DadosListasQueriesHandler;

public class GetDadosListasHandlerAll : IRequestHandler<GetDadosListasAll, ResponseWrapper<List<DadosListasResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDadosListasHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<DadosListasResponse>>> Handle(GetDadosListasAll request, CancellationToken cancellationToken)
    {
        var dadosListasToFind = await _unitOfWork.ReadDataFor<DadosListas>().GetAllAsync();

        if (dadosListasToFind.Count > 0)
        {
            return new ResponseWrapper<List<DadosListasResponse>>().Success(dadosListasToFind.Adapt<List<DadosListasResponse>>());
        }
        return new ResponseWrapper<List<DadosListasResponse>>().Failed("Não foram encontrados registros para a consulta realizada.");
    }
}
