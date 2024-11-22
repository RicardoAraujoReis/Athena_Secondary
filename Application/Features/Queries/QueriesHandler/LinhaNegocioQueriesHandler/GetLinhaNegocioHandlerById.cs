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

public class GetLinhaNegocioHandlerById : IRequestHandler<GetLinhaNegocioById, ResponseWrapper<LinhaNegocioResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetLinhaNegocioHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<LinhaNegocioResponse>> Handle(GetLinhaNegocioById request, CancellationToken cancellationToken)
    {
        if(request is not null && request.Id > 0)
        {
            var linhaNegocioToFind = await _unitOfWork.ReadDataFor<LinhaNegocio>().GetByIdAsync(request.Id);

            if (linhaNegocioToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Success(linhaNegocioToFind.
                    Adapt<LinhaNegocioResponse>()));
            }
            return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Failed("Registro não encontrado"));
        }
        else
        {
            return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Failed("Id precisa ser maior que 0"));            
        }                
    }
}