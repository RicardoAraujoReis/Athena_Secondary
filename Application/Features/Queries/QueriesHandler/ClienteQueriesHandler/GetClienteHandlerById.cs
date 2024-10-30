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

public class GetClienteHandlerById : IRequestHandler<GetClienteById, ResponseWrapper<ClienteResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetClienteHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<ClienteResponse>> Handle(GetClienteById request, CancellationToken cancellationToken)
    {
        var clienteToFind = await _unitOfWork.ReadDataFor<Cliente>().GetByIdAsync(request.Cli_identi);

        if (clienteToFind is not null)
        {
            return new ResponseWrapper<ClienteResponse>().Success(clienteToFind.Adapt<ClienteResponse>());
        }
        return new ResponseWrapper<ClienteResponse>().Failed("Registro não encontrado");
    }
}
