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

public class GetClienteHandlerByStatus : IRequestHandler<GetClienteByStatus, ResponseWrapper<List<ClienteResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetClienteHandlerByStatus(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<ClienteResponse>>> Handle(GetClienteByStatus request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.StatusCliente))
        {
            var clienteToFind = _unitOfWork.ReadDataFor<Cliente>()
            .Entities
            .Where(cliente => cliente.Cli_ativo == request.StatusCliente)
            .ToList();

            if (clienteToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<ClienteResponse>>().
                    Success(clienteToFind.
                    Adapt<List<ClienteResponse>>()));
            }
            return new ResponseWrapper<List<ClienteResponse>>().Failed("Registro não encontrado");
        }
        return new ResponseWrapper<List<ClienteResponse>>().Failed("Parâmetro obrigatório não preenchido");
    }
}