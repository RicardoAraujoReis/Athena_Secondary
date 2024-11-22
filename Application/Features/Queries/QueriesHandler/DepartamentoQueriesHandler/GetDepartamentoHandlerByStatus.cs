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

namespace Application.Features.Queries.QueriesHandler.DepartamentoQueriesHandler;

public class GetDepartamentoHandlerByStatus : IRequestHandler<GetDepartamentoByStatus, ResponseWrapper<List<DepartamentoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDepartamentoHandlerByStatus(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<DepartamentoResponse>>> Handle(GetDepartamentoByStatus request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.StatusDepartamento))
        {
            var DepartamentoToFind = _unitOfWork.ReadDataFor<Departamento>()
            .Entities
            .Where(Departamento => Departamento.Dpt_ativo == request.StatusDepartamento)
            .ToList();

            if (DepartamentoToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<DepartamentoResponse>>().
                    Success(DepartamentoToFind.
                    Adapt<List<DepartamentoResponse>>()));
            }
            return new ResponseWrapper<List<DepartamentoResponse>>().Failed("Registro não encontrado");
        }
        return new ResponseWrapper<List<DepartamentoResponse>>().Failed("Parâmetro obrigatório não preenchido");
    }
}