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

public class GetDadosListasHandlerById : IRequestHandler<GetDadosListasById, ResponseWrapper<DadosListasResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDadosListasHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<DadosListasResponse>> Handle(GetDadosListasById request, CancellationToken cancellationToken)
    {
        var dadosListasToFind = await _unitOfWork.ReadDataFor<DadosListas>().GetByIdAsync(request.Id);

        if (dadosListasToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<DadosListasResponse>().
                Success(dadosListasToFind.
                Adapt<DadosListasResponse>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<DadosListasResponse>().
                Failed("Registro não encontrado"));
    }
}