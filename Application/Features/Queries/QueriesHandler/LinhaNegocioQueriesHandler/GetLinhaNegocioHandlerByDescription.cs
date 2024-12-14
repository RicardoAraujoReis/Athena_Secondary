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

public class GetLinhaNegocioHandlerByDescription : IRequestHandler<GetLinhaNegocioByDescription, ResponseWrapper<List<LinhaNegocioResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetLinhaNegocioHandlerByDescription(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<LinhaNegocioResponse>>> Handle(GetLinhaNegocioByDescription request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.descricao))
        {
            var linhaNegocioToFind = _unitOfWork.ReadDataFor<LinhaNegocio>()
            .Entities
            .Where(linhaNegocio => linhaNegocio.Lhn_descri.ToUpper().Contains(request.descricao.ToUpper()));

            if (linhaNegocioToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Success(linhaNegocioToFind.
                    Adapt<List<LinhaNegocioResponse>>()));
            }
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Nenhum registro encontrado"));
        }        
        else 
        {
            return await Task.
                    FromResult(new ResponseWrapper<List<LinhaNegocioResponse>>().
                    Failed("Informações inválidas para a consulta"));
        }            
    }
}