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

public class GetClienteHandlerByName : IRequestHandler<GetClienteByName, ResponseWrapper<ClienteResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetClienteHandlerByName(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<ClienteResponse>> Handle(GetClienteByName request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.NomeCliente))
        {
            var clienteToFind = _unitOfWork.ReadDataFor<Cliente>()
            .Entities
            .Where(cliente => cliente.Cli_descri.ToUpper() == request.NomeCliente.ToUpper())
            .FirstOrDefault();

            if (clienteToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<ClienteResponse>().
                    Success(clienteToFind.
                    Adapt<ClienteResponse>()));
            }
            return new ResponseWrapper<ClienteResponse>().Failed("Registro não encontrado");
        }
        return new ResponseWrapper<ClienteResponse>().Failed("Parâmetro obrigatório não preenchido");
    }    
}