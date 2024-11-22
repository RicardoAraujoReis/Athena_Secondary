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

public class GetLinhaNegocioHandlerBySearchParameters : IRequestHandler<GetLinhaNegocioBySearchParameters, ResponseWrapper<List<LinhaNegocioResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetLinhaNegocioHandlerBySearchParameters(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<LinhaNegocioResponse>>> Handle(GetLinhaNegocioBySearchParameters request, CancellationToken cancellationToken)
    {
        //var query = _unitOfWork.ReadDataFor<LinhaNegocio>().Entities.AsQueryable();

        if(!string.IsNullOrEmpty(request.Id.ToString()) && request.Id > 0 && string.IsNullOrEmpty(request.LinhaNegocioByStatus))
        {
            var linhaNegocioToFindById = await _unitOfWork.ReadDataFor<LinhaNegocio>().GetByIdAsync(request.Id);

            if (linhaNegocioToFindById is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Success(linhaNegocioToFindById.
                    Adapt<List<LinhaNegocioResponse>>()));
            }
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Registro não encontrado"));
        }
        else if (request.Id == 0 && !string.IsNullOrWhiteSpace(request.LinhaNegocioByStatus))
        {
            var linhaNegocioToFindByStatus = _unitOfWork.ReadDataFor<LinhaNegocio>()
            .Entities
            .Where(linhaNegocio => linhaNegocio.Lhn_ativo == request.LinhaNegocioByStatus)
            .ToList();

            if (linhaNegocioToFindByStatus is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Success(linhaNegocioToFindByStatus.Adapt<List<LinhaNegocioResponse>>()));
            }
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Registro não encontrado"));
        }
        else if (!string.IsNullOrEmpty(request.Id.ToString()) && request.Id > 0 && !string.IsNullOrEmpty(request.LinhaNegocioByStatus))
        {
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Consulta por dois ou mais parâmetros não permitida"));
        }
        else if (!string.IsNullOrEmpty(request.Id.ToString()) && request.Id == 0 && string.IsNullOrEmpty(request.LinhaNegocioByStatus))
        {
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Id não pode ser 0"));
        }
        else
        {
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Registro não encontrado"));
        }
    }    
}