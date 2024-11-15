using Athena.Models;
using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.QueriesHandler.LinhaNegocioQueriesHandler;

public class GetLinhaNegocioHandlerByStatus : IRequestHandler<GetLinhaNegocioByStatus, ResponseWrapper<LinhaNegocioResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetLinhaNegocioHandlerByStatus(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<LinhaNegocioResponse>> Handle(GetLinhaNegocioByStatus request, CancellationToken cancellationToken)
    {
        if (request.LinhaNegocioByStatus != null && request.LinhaNegocioByStatus.Length == 1)
        {
            var linhaNegocioToFind = _unitOfWork.ReadDataFor<LinhaNegocio>()
            .Entities
            .Where(linhaNegocio => linhaNegocio.Lhn_ativo == request.LinhaNegocioByStatus)
            .FirstOrDefault();

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
        else if (request.LinhaNegocioByStatus != null && request.LinhaNegocioByStatus.Length != 1)
        {            
            return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Failed($"Status {request.LinhaNegocioByStatus} maior que o tamanho máximo de 1 caractere"));
        }
        else 
        {
            return await Task.
                    FromResult(new ResponseWrapper<LinhaNegocioResponse>().
                    Failed("Status não pode ser vazio"));
        }            
    }
}