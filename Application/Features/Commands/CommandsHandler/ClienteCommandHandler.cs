using Application.Features.Commands;
using Athena.Models;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CommandsHandler;

public class CreateClienteCommandsHandler : IRequestHandler<CreateClienteCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateClienteCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var Cliente = request.CreateCliente.Adapt<Cliente>();
        await _unitOfWork.WriteDataFor<Cliente>().AddAsync(Cliente);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(Cliente.Id, "Registro criado com sucesso.");
    }
}

public class UpdateClienteCommandsHandler : IRequestHandler<UpdateClienteCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateClienteCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var ClienteToFind = await _unitOfWork.ReadDataFor<Cliente>().GetByIdAsync(request.UpdateCliente.Id);

        if (ClienteToFind is not null)
        {
            var updateCliente = new Cliente
            {
                Id = request.UpdateCliente.Id,
                Cli_descri = request.UpdateCliente.Cli_descri,
                Cli_ativo = request.UpdateCliente.Cli_ativo,
                Cli_usubdd = request.UpdateCliente.Cli_usubdd,
                Cli_usucri = request.UpdateCliente.Cli_usucri,
                Cli_usualt = request.UpdateCliente.Cli_usualt,
                Cli_datcri = request.UpdateCliente.Cli_datcri,
                Cli_datalt = request.UpdateCliente.Cli_datalt,
                Cli_lhn_identi = request.UpdateCliente.Cli_lhn_identi
            };
                           

            await _unitOfWork.WriteDataFor<Cliente>().UpdateAsync(updateCliente);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateCliente.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteClienteCommandsHandler : IRequestHandler<DeleteClienteCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteClienteCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var ClienteToFind = await _unitOfWork.ReadDataFor<Cliente>().GetByIdAsync(request.IdClienteToDelete);

        if (ClienteToFind is not null)
        {
            await _unitOfWork.WriteDataFor<Cliente>().DeleteAsync(ClienteToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(ClienteToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
