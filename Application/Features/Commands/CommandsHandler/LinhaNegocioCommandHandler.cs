using Application.Features.Commands;
using Athena.Models;
using Common.Requests;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CommandsHandler;

public class CreateLinhaNegocioCommandsHandler : IRequestHandler<CreateLinhaNegocioCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateLinhaNegocioCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateLinhaNegocioCommand request, CancellationToken cancellationToken)
    {
        var LinhaNegocio = request.CreateLinhaNegocio.Adapt<LinhaNegocio>();
        await _unitOfWork.WriteDataFor<LinhaNegocio>().AddAsync(LinhaNegocio);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(LinhaNegocio.Id, "Registro criado com sucesso.");
    }
}

public class UpdateLinhaNegocioCommandsHandler : IRequestHandler<UpdateLinhaNegocioCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateLinhaNegocioCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateLinhaNegocioCommand request, CancellationToken cancellationToken)
    {
        var LinhaNegocioToFind = await _unitOfWork.ReadDataFor<LinhaNegocio>().GetByIdAsync(request.UpdateLinhaNegocio.Id);

        if (LinhaNegocioToFind is not null)
        {
            var updateLinhaNegocio = new LinhaNegocio
            {
                Id = request.UpdateLinhaNegocio.Id,                
                Lhn_descri = request.UpdateLinhaNegocio.Lhn_descri,
                Lhn_ativo =  request.UpdateLinhaNegocio.Lhn_ativo,
                Lhn_usubdd = request.UpdateLinhaNegocio.Lhn_usubdd,
                Lhn_usucri = request.UpdateLinhaNegocio.Lhn_usucri,
                Lhn_usualt = request.UpdateLinhaNegocio.Lhn_usualt,
                Lhn_datcri = request.UpdateLinhaNegocio.Lhn_datcri,
                Lhn_datalt = request.UpdateLinhaNegocio.Lhn_datalt
            };            

            await _unitOfWork.WriteDataFor<LinhaNegocio>().UpdateAsync(updateLinhaNegocio);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateLinhaNegocio.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteLinhaNegocioCommandsHandler : IRequestHandler<DeleteLinhaNegocioCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteLinhaNegocioCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteLinhaNegocioCommand request, CancellationToken cancellationToken)
    {
        var LinhaNegocioToFind = await _unitOfWork.ReadDataFor<LinhaNegocio>().GetByIdAsync(request.IdLinhaNegocioToDelete);

        if (LinhaNegocioToFind is not null)
        {
            await _unitOfWork.WriteDataFor<LinhaNegocio>().DeleteAsync(LinhaNegocioToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(LinhaNegocioToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
