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

public class CreateUsuarioCommandsHandler : IRequestHandler<CreateUsuarioCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateUsuarioCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var Usuario = request.CreateUsuario.Adapt<Usuario>();
        await _unitOfWork.WriteDataFor<Usuario>().AddAsync(Usuario);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(Usuario.Id, "Registro criado com sucesso.");
    }
}

public class UpdateUsuarioCommandsHandler : IRequestHandler<UpdateUsuarioCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateUsuarioCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var UsuarioToFind = await _unitOfWork.ReadDataFor<Usuario>().GetByIdAsync(request.UpdateUsuario.Id);

        if (UsuarioToFind is not null)
        {
            var updateUsuario = new Usuario
            {
                Id = request.UpdateUsuario.Id,
                Usu_descri = request.UpdateUsuario.Usu_descri,
                Usu_login = request.UpdateUsuario.Usu_login,
                Usu_senha = request.UpdateUsuario.Usu_senha,
                Usu_email = request.UpdateUsuario.Usu_email,
                Usu_ativo = request.UpdateUsuario.Usu_ativo,
                Usu_status = request.UpdateUsuario.Usu_status,
                Usu_master = request.UpdateUsuario.Usu_master,
                Usu_tipusu = request.UpdateUsuario.Usu_tipusu,
                Usu_usubdd = request.UpdateUsuario.Usu_usubdd,
                Usu_usucri = request.UpdateUsuario.Usu_usucri,
                Usu_usualt = request.UpdateUsuario.Usu_usualt,
                Usu_datcri = request.UpdateUsuario.Usu_datcri,
                Usu_datalt = request.UpdateUsuario.Usu_datalt
            };

            await _unitOfWork.WriteDataFor<Usuario>().UpdateAsync(updateUsuario);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateUsuario.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteUsuarioCommandsHandler : IRequestHandler<DeleteUsuarioCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteUsuarioCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var UsuarioToFind = await _unitOfWork.ReadDataFor<Usuario>().GetByIdAsync(request.IdUsuarioToDelete);

        if (UsuarioToFind is not null)
        {
            await _unitOfWork.WriteDataFor<Usuario>().DeleteAsync(UsuarioToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(UsuarioToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
