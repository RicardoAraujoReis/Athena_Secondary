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
        bool isValid = CreateDepartamentoValidator(Departamento);

        if (isValid)
        {
            await _unitOfWork.WriteDataFor<Departamento>().AddAsync(Departamento);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseWrapper<int>().Success(Departamento.Id, "Registro criado com sucesso.");
        }
        return new ResponseWrapper<int>().Failed("Falha ao criar o registro");
    }

    public bool CreateDepartamentoValidator(Departamento departamentoRequest)
    {
        if (Convert.ToChar(departamentoRequest.Dpt_ativo.ToUpper()) != 'S')
        {
            return false;
        }
        else if (departamentoRequest.Dpt_ativo.Length > 1)
        {
            return false;
        }
        else if (departamentoRequest.Dpt_usucri == 0)
        {
            return false;
        }
        return true;
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
        var DepartamentoToFind = await _unitOfWork.ReadDataFor<Departamento>().GetByIdAsync(request.UpdateDepartamento.Id);
        var ValidaDepartamento = request.UpdateDepartamento.Adapt<Departamento>();
        bool isValid = UpdateDepartamentoValidator(ValidaDepartamento, DepartamentoToFind);

        if (isValid)
        {                     
            var updateDepartamento = new Departamento
                {
                    Id = request.UpdateDepartamento.Id,
                    Dpt_descri = request.UpdateDepartamento.Dpt_descri,
                    Dpt_ativo = request.UpdateDepartamento.Dpt_ativo,
                    Dpt_usubdd = request.UpdateDepartamento.Dpt_usubdd,
                    Dpt_usucri = request.UpdateDepartamento.Dpt_usucri,
                    Dpt_usualt = request.UpdateDepartamento.Dpt_usualt,
                    Dpt_datcri = request.UpdateDepartamento.Dpt_datcri,
                    Dpt_datalt = request.UpdateDepartamento.Dpt_datalt
                };

            await _unitOfWork.WriteDataFor<Departamento>().UpdateAsync(updateDepartamento);
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return new ResponseWrapper<int>().Success(updateDepartamento.Id, "Atualização realizada com sucesso");
        }
            return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");                
    }

    public bool UpdateDepartamentoValidator(Departamento departamentoRequest, Departamento departamento)
    {
        if (departamentoRequest.Dpt_ativo.Length > 1)
        {
            return false;
        }
        else if (departamentoRequest.Dpt_usucri == 0)
        {
            return false;
        }
        return true;
    }
}

public class DeleteDepartamentoCommandsHandler : IRequestHandler<DeleteDepartamentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteDepartamentoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteDepartamentoCommand request, CancellationToken cancellationToken)
    {
        var DepartamentoToFind = await _unitOfWork.ReadDataFor<Departamento>().GetByIdAsync(request.IdDepartamentoToDelete);

        if (DepartamentoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<Departamento>().DeleteAsync(DepartamentoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(DepartamentoToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}