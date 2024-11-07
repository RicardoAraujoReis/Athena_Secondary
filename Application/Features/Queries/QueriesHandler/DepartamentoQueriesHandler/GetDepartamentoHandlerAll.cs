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

public class GetDepartamentoHandlerAll : IRequestHandler<GetDepartamentoAll, ResponseWrapper<List<DepartamentoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDepartamentoHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<DepartamentoResponse>>> Handle(GetDepartamentoAll request, CancellationToken cancellationToken)
    {
        var departamentoToFind = await _unitOfWork.ReadDataFor<Departamento>().GetAllAsync();

        if (departamentoToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<DepartamentoResponse>>().
                Success(departamentoToFind.
                Adapt<List<DepartamentoResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<DepartamentoResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}