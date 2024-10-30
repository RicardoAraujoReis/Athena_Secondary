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

public class CreateDepartamentoCommandsHandler : IRequestHandler<CreateDepartamentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateDepartamentoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateDepartamentoCommand request, CancellationToken cancellationToken)
    {
        var Departamento = request.CreateDepartamento.Adapt<Departamento>();
        await _unitOfWork.WriteDataFor<Departamento>().AddAsync(Departamento);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(Departamento.Dpt_identi, "Registro criado com sucesso.");
    }
}

public class UpdateDepartamentoCommandsHandler : IRequestHandler<UpdateDepartamentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateDepartamentoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateDepartamentoCommand request, CancellationToken cancellationToken)
    {
        var DepartamentoToFind = await _unitOfWork.ReadDataFor<Departamento>().GetByIdAsync(request.UpdateDepartamento.Dpt_identi);

        if (DepartamentoToFind is not null)
        {
            var updateDepartamento = DepartamentoToFind.UpdateDepartamento(
                request.UpdateDepartamento.Dpt_identi,
                request.UpdateDepartamento.Dpt_descri,
                request.UpdateDepartamento.Dpt_ativo,
                request.UpdateDepartamento.Dpt_usubdd,
                request.UpdateDepartamento.Dpt_usucri,
                request.UpdateDepartamento.Dpt_usualt,
                request.UpdateDepartamento.Dpt_datcri,
                request.UpdateDepartamento.Dpt_datalt
            );

            await _unitOfWork.WriteDataFor<Departamento>().UpdateAsync(updateDepartamento);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateDepartamento.Dpt_identi, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteDepartamentoCommandsHandler : IRequestHandler<DeleteDepartamentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public async Task<ResponseWrapper<int>> Handle(DeleteDepartamentoCommand request, CancellationToken cancellationToken)
    {
        var DepartamentoToFind = await _unitOfWork.ReadDataFor<Departamento>().GetByIdAsync(request.IdDepartamentoToDelete);

        if (DepartamentoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<Departamento>().DeleteAsync(DepartamentoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(DepartamentoToFind.Dpt_identi, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
