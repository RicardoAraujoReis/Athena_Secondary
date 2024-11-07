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

public class CreateCategoriaAtendimentoCommandsHandler : IRequestHandler<CreateCategoriaAtendimentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateCategoriaAtendimentoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateCategoriaAtendimentoCommand request, CancellationToken cancellationToken)
    {
        var CategoriaAtendimento = request.CreateCategoriaAtendimento.Adapt<CategoriaAtendimento>();
        await _unitOfWork.WriteDataFor<CategoriaAtendimento>().AddAsync(CategoriaAtendimento);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(CategoriaAtendimento.Id, "Registro criado com sucesso.");
    }
}

public class UpdateCategoriaAtendimentoCommandsHandler : IRequestHandler<UpdateCategoriaAtendimentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateCategoriaAtendimentoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateCategoriaAtendimentoCommand request, CancellationToken cancellationToken)
    {
        var CategoriaAtendimentoToFind = await _unitOfWork.ReadDataFor<CategoriaAtendimento>().GetByIdAsync(request.UpdateCategoriaAtendimento.Id);

        if (CategoriaAtendimentoToFind is not null)
        {
            var updateCategoriaAtendimento = new CategoriaAtendimento
            {
                Id = request.UpdateCategoriaAtendimento.Id,
                Cat_catpai = request.UpdateCategoriaAtendimento.Cat_catpai,
                Cat_nivel = request.UpdateCategoriaAtendimento.Cat_nivel,
                Cat_valor = request.UpdateCategoriaAtendimento.Cat_valor,
                Cat_usubdd = request.UpdateCategoriaAtendimento.Cat_usubdd,
                Cat_usucri = request.UpdateCategoriaAtendimento.Cat_usucri,
                Cat_usualt = request.UpdateCategoriaAtendimento.Cat_usualt,
                Cat_datcri = request.UpdateCategoriaAtendimento.Cat_datcri,
                Cat_datalt = request.UpdateCategoriaAtendimento.Cat_datalt
            };                            

            await _unitOfWork.WriteDataFor<CategoriaAtendimento>().UpdateAsync(updateCategoriaAtendimento);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateCategoriaAtendimento.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteCategoriaAtendimentoCommandsHandler : IRequestHandler<DeleteCategoriaAtendimentoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteCategoriaAtendimentoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteCategoriaAtendimentoCommand request, CancellationToken cancellationToken)
    {
        var CategoriaAtendimentoToFind = await _unitOfWork.ReadDataFor<CategoriaAtendimento>().GetByIdAsync(request.IdCategoriaAtendimentoToDelete);

        if (CategoriaAtendimentoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<CategoriaAtendimento>().DeleteAsync(CategoriaAtendimentoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(CategoriaAtendimentoToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
