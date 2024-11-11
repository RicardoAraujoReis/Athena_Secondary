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
        var Funcao = request.CreateFuncao.Adapt<Funcao>();
        await _unitOfWork.WriteDataFor<Funcao>().AddAsync(Funcao);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(Funcao.Id, "Registro criado com sucesso.");
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

        if (FuncaoToFind is not null)
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
