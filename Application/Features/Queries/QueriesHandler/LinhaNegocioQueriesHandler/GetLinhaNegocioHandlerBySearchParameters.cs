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
        // Inicia a consulta
        var query = _unitOfWork.ReadDataFor<LinhaNegocio>().Entities.AsQueryable();

        // Aplica o filtro condicional para o status, se especificado
        if (!string.IsNullOrWhiteSpace(request.LinhaNegocioByStatus))
        {
            query = query.Where(linhaNegocio => linhaNegocio.Lhn_ativo == request.LinhaNegocioByStatus);
        }

        // Aplica o filtro condicional para o ID, se especificado
        if (request.Id > 0)
        {
            query = query.Where(linhaNegocio => linhaNegocio.Id == request.Id);
        }

        // Executa a consulta com os filtros aplicados
        var linhaNegocioToFind = query.FirstOrDefault();

        if (linhaNegocioToFind is not null)
        {
            return await Task.FromResult(
                new ResponseWrapper<LinhaNegocioResponse>()
                    .Success(linhaNegocioToFind.Adapt<LinhaNegocioResponse>())
            );
        }

        return await Task.FromResult(
            new ResponseWrapper<LinhaNegocioResponse>().Failed("Registro não encontrado")
        );
    }
}
