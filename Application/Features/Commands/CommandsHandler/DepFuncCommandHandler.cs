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

public class CreateDepFuncCommandsHandler : IRequestHandler<CreateDepFuncCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateDepFuncCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateDepFuncCommand request, CancellationToken cancellationToken)
    {
        var DepFunc = request.CreateDepFunc.Adapt<DepFunc>();
        await _unitOfWork.WriteDataFor<DepFunc>().AddAsync(DepFunc);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(DepFunc.Id, "Registro criado com sucesso.");
    }
}

public class UpdateDepFuncCommandsHandler : IRequestHandler<UpdateDepFuncCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateDepFuncCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateDepFuncCommand request, CancellationToken cancellationToken)
    {
        var DepFuncToFind = await _unitOfWork.ReadDataFor<DepFunc>().GetByIdAsync(request.UpdateDepFunc.Id);

        if (DepFuncToFind is not null)
        {
            var updateDepFunc = new DepFunc
            {
                Id = request.UpdateDepFunc.Id,
                Dfc_dpt_identi = request.UpdateDepFunc.Dfc_dpt_identi,
                Dfc_fnc_identi = request.UpdateDepFunc.Dfc_fnc_identi,
                Dfc_usu_identi = request.UpdateDepFunc.Dfc_usu_identi,
                Dfc_usubdd = request.UpdateDepFunc.Dfc_usubdd,
                Dfc_usucri = request.UpdateDepFunc.Dfc_usucri,
                Dfc_usualt = request.UpdateDepFunc.Dfc_usualt,
                Dfc_datcri = request.UpdateDepFunc.Dfc_datcri,
                Dfc_datalt = request.UpdateDepFunc.Dfc_datalt
            };                            

            await _unitOfWork.WriteDataFor<DepFunc>().UpdateAsync(updateDepFunc);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateDepFunc.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteDepFuncCommandsHandler : IRequestHandler<DeleteDepFuncCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteDepFuncCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteDepFuncCommand request, CancellationToken cancellationToken)
    {
        var DepFuncToFind = await _unitOfWork.ReadDataFor<DepFunc>().GetByIdAsync(request.IdDepFuncToDelete);

        if (DepFuncToFind is not null)
        {
            await _unitOfWork.WriteDataFor<DepFunc>().DeleteAsync(DepFuncToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(DepFuncToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
