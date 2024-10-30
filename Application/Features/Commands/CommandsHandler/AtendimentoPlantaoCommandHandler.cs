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

public class CreateAtendimentoPlantaoCommandsHandler : IRequestHandler<CreateAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateAtendimentoPlantaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var atendimentoPlantao = request.CreateAtendimentoPlantao.Adapt<AtendimentoPlantao>();
        await _unitOfWork.WriteDataFor<AtendimentoPlantao>().AddAsync(atendimentoPlantao);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(atendimentoPlantao.Atd_identi, "Registro criado com sucesso.");
    }
}

public class UpdateAtendimentoPlantaoCommandsHandler : IRequestHandler<UpdateAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateAtendimentoPlantaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<AtendimentoPlantao>().GetByIdAsync(request.UpdateAtendimentoPlantao.atd_identi);

        if (atendimentoPlantaoToFind is not null)
        {
            var updateAtendimentoPlantao = atendimentoPlantaoToFind.UpdateAtendimentoPlantao(
                request.UpdateAtendimentoPlantao.atd_identi,
                request.UpdateAtendimentoPlantao.atd_usu_identi,
                request.UpdateAtendimentoPlantao.atd_cli_identi,
                request.UpdateAtendimentoPlantao.atd_tipatd,
                request.UpdateAtendimentoPlantao.atd_cat_identi,
                request.UpdateAtendimentoPlantao.atd_resumo,
                request.UpdateAtendimentoPlantao.atd_respn2,
                request.UpdateAtendimentoPlantao.atd_crijir,
                request.UpdateAtendimentoPlantao.atd_issue,
                request.UpdateAtendimentoPlantao.atd_critic,
                request.UpdateAtendimentoPlantao.atd_resplt,
                request.UpdateAtendimentoPlantao.atd_ren1hm,
                request.UpdateAtendimentoPlantao.atd_resn1,
                request.UpdateAtendimentoPlantao.atd_evoln1,
                request.UpdateAtendimentoPlantao.atd_observ,
                request.UpdateAtendimentoPlantao.atd_usubdd,
                request.UpdateAtendimentoPlantao.atd_datatd,
                request.UpdateAtendimentoPlantao.atd_nomal2,
                request.UpdateAtendimentoPlantao.atd_status,
                request.UpdateAtendimentoPlantao.atd_usucri,
                request.UpdateAtendimentoPlantao.atd_usualt,
                request.UpdateAtendimentoPlantao.atd_datcri,
                request.UpdateAtendimentoPlantao.atd_datalt
            );

            await _unitOfWork.WriteDataFor<AtendimentoPlantao>().UpdateAsync(updateAtendimentoPlantao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateAtendimentoPlantao.Atd_identi, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteAtendimentoPlantaoCommandsHandler : IRequestHandler<DeleteAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public async Task<ResponseWrapper<int>> Handle(DeleteAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<AtendimentoPlantao>().GetByIdAsync(request.IdAtendimentoPlantaoToDelete);

        if (atendimentoPlantaoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<AtendimentoPlantao>().DeleteAsync(atendimentoPlantaoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(atendimentoPlantaoToFind.Atd_identi, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
