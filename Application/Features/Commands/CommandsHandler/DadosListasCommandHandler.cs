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

public class CreateDadosListasCommandsHandler : IRequestHandler<CreateDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateDadosListasCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateDadosListasCommand request, CancellationToken cancellationToken)
    {
        var DadosListas = request.CreateDadosListas.Adapt<DadosListas>();
        await _unitOfWork.WriteDataFor<DadosListas>().AddAsync(DadosListas);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(DadosListas.Dal_identi, "Registro criado com sucesso.");
    }
}

public class UpdateDadosListasCommandsHandler : IRequestHandler<UpdateDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateDadosListasCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateDadosListasCommand request, CancellationToken cancellationToken)
    {
        var DadosListasToFind = await _unitOfWork.ReadDataFor<DadosListas>().GetByIdAsync(request.UpdateDadosListas.Dal_identi);

        if (DadosListasToFind is not null)
        {
            var updateDadosListas = DadosListasToFind.UpdateDadosListas(
                request.UpdateDadosListas.Dal_identi,
                request.UpdateDadosListas.Dal_tid_identi,
                request.UpdateDadosListas.Dal_valor,
                request.UpdateDadosListas.Dal_usubdd,
                request.UpdateDadosListas.Dal_datcri,
                request.UpdateDadosListas.Dal_datalt,
                request.UpdateDadosListas.Dal_usucri,
                request.UpdateDadosListas.Dal_usualt
            );

            await _unitOfWork.WriteDataFor<DadosListas>().UpdateAsync(updateDadosListas);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateDadosListas.Dal_identi, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteDadosListasCommandsHandler : IRequestHandler<DeleteDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public async Task<ResponseWrapper<int>> Handle(DeleteDadosListasCommand request, CancellationToken cancellationToken)
    {
        var DadosListasToFind = await _unitOfWork.ReadDataFor<DadosListas>().GetByIdAsync(request.IdDadosListasToDelete);

        if (DadosListasToFind is not null)
        {
            await _unitOfWork.WriteDataFor<DadosListas>().DeleteAsync(DadosListasToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(DadosListasToFind.Dal_identi, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
