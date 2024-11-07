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

public class GetLinhaNegocioHandlerBySearchParameters : IRequestHandler<GetLinhaNegocioBySearchParameters, ResponseWrapper<LinhaNegocioResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetLinhaNegocioHandlerBySearchParameters(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<LinhaNegocioResponse>> Handle(GetLinhaNegocioBySearchParameters request, CancellationToken cancellationToken)
    {
        if (request.Id.ToString() is not null)
        {
            var linhaNegocioToFindById = await _unitOfWork.ReadDataFor<LinhaNegocio>().GetByIdAsync(Convert.ToInt32(request.Id));

            if (linhaNegocioToFindById is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Success(linhaNegocioToFindById.
                    Adapt<LinhaNegocioResponse>()));
            }
            return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Failed("Registro não encontrado"));
        }

        if (request.LinhaNegocioByStatus is not null)
        {
            var linhaNegocioToFindByStatus = _unitOfWork.ReadDataFor<LinhaNegocio>()
            .Entities
            .Where(linhaNegocio => linhaNegocio.Lhn_ativo == request.LinhaNegocioByStatus)
            .FirstOrDefault();

            if (linhaNegocioToFindByStatus is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Success(linhaNegocioToFindByStatus.
                    Adapt<LinhaNegocioResponse>()));
            }
            return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Failed("Registro não encontrado"));
        }

        return null;
    }
}