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

        return new ResponseWrapper<int>().Success(DadosListas.Id, "Registro criado com sucesso.");
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
        var DadosListasToFind = await _unitOfWork.ReadDataFor<DadosListas>().GetByIdAsync(request.UpdateDadosListas.Id);

        if (DadosListasToFind is not null)
        {
            var updateDadosListas = new DadosListas
            {
                Id = request.UpdateDadosListas.Id,
                Dal_tid_identi = request.UpdateDadosListas.Dal_tid_identi,
                Dal_tid_descri = request.UpdateDadosListas.Dal_tid_descri,
                Dal_aplicacao = request.UpdateDadosListas.Dal_aplicacao,
                Dal_valor = request.UpdateDadosListas.Dal_valor,
                Dal_usubdd = request.UpdateDadosListas.Dal_usubdd,
                Dal_datcri = request.UpdateDadosListas.Dal_datcri,
                Dal_datalt = request.UpdateDadosListas.Dal_datalt,
                Dal_usucri = request.UpdateDadosListas.Dal_usucri,
                Dal_usualt = request.UpdateDadosListas.Dal_usualt
            };                           

            await _unitOfWork.WriteDataFor<DadosListas>().UpdateAsync(updateDadosListas);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateDadosListas.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteDadosListasCommandsHandler : IRequestHandler<DeleteDadosListasCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteDadosListasCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteDadosListasCommand request, CancellationToken cancellationToken)
    {
        var DadosListasToFind = await _unitOfWork.ReadDataFor<DadosListas>().GetByIdAsync(request.IdDadosListasToDelete);

        if (DadosListasToFind is not null)
        {
            await _unitOfWork.WriteDataFor<DadosListas>().DeleteAsync(DadosListasToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(DadosListasToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
