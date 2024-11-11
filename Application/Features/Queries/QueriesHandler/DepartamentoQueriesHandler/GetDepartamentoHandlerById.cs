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

public class GetDepartamentoHandlerById : IRequestHandler<GetDepartamentoById, ResponseWrapper<DepartamentoResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetDepartamentoHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<DepartamentoResponse>> Handle(GetDepartamentoById request, CancellationToken cancellationToken)
    {
        var departamentoToFind = await _unitOfWork.ReadDataFor<Departamento>().GetByIdAsync(request.Id);

        if (departamentoToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<DepartamentoResponse>().
                Success(departamentoToFind.
                Adapt<DepartamentoResponse>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<DepartamentoResponse>().
                Failed("Registro não encontrado"));
    }
}