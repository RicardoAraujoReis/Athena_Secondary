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

public class CreateTipoDadosListasCommandsHandler : IRequestHandler<CreateTipoDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateTipoDadosListasCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateTipoDadosListasCommand request, CancellationToken cancellationToken)
    {
        var TipoDadosListas = request.CreateTipoDadosListas.Adapt<TipoDadosListas>();
        await _unitOfWork.WriteDataFor<TipoDadosListas>().AddAsync(TipoDadosListas);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(TipoDadosListas.Tid_identi, "Registro criado com sucesso.");
    }
}

public class UpdateTipoDadosListasCommandsHandler : IRequestHandler<UpdateTipoDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateTipoDadosListasCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateTipoDadosListasCommand request, CancellationToken cancellationToken)
    {
        var TipoDadosListasToFind = await _unitOfWork.ReadDataFor<TipoDadosListas>().GetByIdAsync(request.UpdateTipoDadosListas.Tid_identi);

        if (TipoDadosListasToFind is not null)
        {
            var updateTipoDadosListas = TipoDadosListasToFind.UpdateTipoDadosListas(
                request.UpdateTipoDadosListas.Tid_identi,
                request.UpdateTipoDadosListas.Tid_descri,
                request.UpdateTipoDadosListas.Tid_usubdd,
                request.UpdateTipoDadosListas.Tid_datcri,
                request.UpdateTipoDadosListas.Tid_datalt,
                request.UpdateTipoDadosListas.Tid_usucri,
                request.UpdateTipoDadosListas.Tid_usualt
            );

            await _unitOfWork.WriteDataFor<TipoDadosListas>().UpdateAsync(updateTipoDadosListas);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateTipoDadosListas.Tid_identi, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteTipoDadosListasCommandsHandler : IRequestHandler<DeleteTipoDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public async Task<ResponseWrapper<int>> Handle(DeleteTipoDadosListasCommand request, CancellationToken cancellationToken)
    {
        var TipoDadosListasToFind = await _unitOfWork.ReadDataFor<TipoDadosListas>().GetByIdAsync(request.IdTipoDadosListasToDelete);

        if (TipoDadosListasToFind is not null)
        {
            await _unitOfWork.WriteDataFor<TipoDadosListas>().DeleteAsync(TipoDadosListasToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(TipoDadosListasToFind.Tid_identi, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
