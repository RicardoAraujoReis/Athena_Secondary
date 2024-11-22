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

public class CreateFuncaoCommandsHandler : IRequestHandler<CreateFuncaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateFuncaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateFuncaoCommand request, CancellationToken cancellationToken)
    {
        var funcao = request.CreateFuncao.Adapt<Funcao>();
        bool isValid = CreateFuncaoValidator(funcao);

        if (isValid)
        {
            await _unitOfWork.WriteDataFor<Funcao>().AddAsync(funcao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(funcao.Id, "Registro criado com sucesso.");
        }
        return new ResponseWrapper<int>().Failed("Falha ao criar o registro");
    }

    public bool CreateFuncaoValidator(Funcao funcaoRequest)
    {
        if (Convert.ToChar(funcaoRequest.Fnc_ativo.ToUpper()) != 'S')
        {
            return false;
        }
        else if (funcaoRequest.Fnc_ativo.Length > 1)
        {
            return false;
        }
        else if (funcaoRequest.Fnc_usucri == 0)
        {
            return false;
        }
        return true;
    }
}

public class UpdateFuncaoCommandsHandler : IRequestHandler<UpdateFuncaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateFuncaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateFuncaoCommand request, CancellationToken cancellationToken)
    {
        var FuncaoToFind = await _unitOfWork.ReadDataFor<Funcao>().GetByIdAsync(request.UpdateFuncao.Id);
        var validaFuncao = request.UpdateFuncao.Adapt<Funcao>();
        bool isValid = UpdateFuncaoValidator(validaFuncao, FuncaoToFind);

        if (isValid)
        {
            var updateFuncao = new Funcao
            {
                Id = request.UpdateFuncao.Id,
                Fnc_descri = request.UpdateFuncao.Fnc_descri,
                Fnc_ativo = request.UpdateFuncao.Fnc_ativo,
                Fnc_usubdd = request.UpdateFuncao.Fnc_usubdd,
                Fnc_usucri = request.UpdateFuncao.Fnc_usucri,
                Fnc_usualt = request.UpdateFuncao.Fnc_usualt,
                Fnc_datcri = request.UpdateFuncao.Fnc_datcri,
                Fnc_datalt = request.UpdateFuncao.Fnc_datalt
            };                           

            await _unitOfWork.WriteDataFor<Funcao>().UpdateAsync(updateFuncao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateFuncao.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }

    public bool UpdateFuncaoValidator(Funcao funcaoRequest, Funcao funcao)
    {
        if (funcaoRequest.Fnc_ativo.Length > 1)
        {
            return false;
        }
        else if (funcaoRequest.Fnc_usucri != funcao.Fnc_usucri)
        {
            return false;
        }
        else if (funcaoRequest.Fnc_datcri != funcao.Fnc_datcri)
        {
            return false;
        }        
        return true;
    }
}

public class DeleteFuncaoCommandsHandler : IRequestHandler<DeleteFuncaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteFuncaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseWrapper<int>> Handle(DeleteFuncaoCommand request, CancellationToken cancellationToken)
    {
        var FuncaoToFind = await _unitOfWork.ReadDataFor<Funcao>().GetByIdAsync(request.IdFuncaoToDelete);

        if (FuncaoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<Funcao>().DeleteAsync(FuncaoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(FuncaoToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
