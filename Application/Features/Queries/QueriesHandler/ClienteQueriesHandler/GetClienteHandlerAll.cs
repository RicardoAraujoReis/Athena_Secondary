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

namespace Application.Features.Queries.QueriesHandler.ClienteQueriesHandler;

public class GetClienteHandlerAll : IRequestHandler<GetClienteAll, ResponseWrapper<List<ClienteResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetClienteHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<ClienteResponse>>> Handle(GetClienteAll request, CancellationToken cancellationToken)
    {
        var clienteToFind = await _unitOfWork.ReadDataFor<Cliente>().GetAllAsync();

        if (clienteToFind.Count > 0)
        {
            return new ResponseWrapper<List<ClienteResponse>>().Success(clienteToFind.Adapt<List<ClienteResponse>>());
        }
        return new ResponseWrapper<List<ClienteResponse>>().Failed("Não foram encontrados registros para a consulta realizada.");
    }
}
