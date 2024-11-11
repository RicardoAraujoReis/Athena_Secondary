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

        return new ResponseWrapper<int>().Success(atendimentoPlantao.Id, "Registro criado com sucesso.");
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
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<AtendimentoPlantao>().GetByIdAsync(request.UpdateAtendimentoPlantao.Id);

        if (atendimentoPlantaoToFind is not null)
        {
            var updateAtendimentoPlantao = new AtendimentoPlantao
            {
                Id = request.UpdateAtendimentoPlantao.Id,
                Atd_cli_identi = request.UpdateAtendimentoPlantao.Atd_cli_identi,
                Atd_tipatd = request.UpdateAtendimentoPlantao.Atd_tipatd,
                Atd_cat_identi = request.UpdateAtendimentoPlantao.Atd_cat_identi,
                Atd_resumo = request.UpdateAtendimentoPlantao.Atd_resumo,
                Atd_respn2 = request.UpdateAtendimentoPlantao.Atd_respn2,
                Atd_crijir = request.UpdateAtendimentoPlantao.Atd_crijir,
                Atd_issue = request.UpdateAtendimentoPlantao.Atd_issue,
                Atd_critic = request.UpdateAtendimentoPlantao.Atd_critic,
                Atd_resplt = request.UpdateAtendimentoPlantao.Atd_resplt,
                Atd_ren1hm = request.UpdateAtendimentoPlantao.Atd_ren1hm,
                Atd_resn1 = request.UpdateAtendimentoPlantao.Atd_resn1,
                Atd_evoln1 = request.UpdateAtendimentoPlantao.Atd_evoln1,
                Atd_observ = request.UpdateAtendimentoPlantao.Atd_observ,
                Atd_usubdd = request.UpdateAtendimentoPlantao.Atd_usubdd,
                Atd_datatd = request.UpdateAtendimentoPlantao.Atd_datatd,
                Atd_nomal2 = request.UpdateAtendimentoPlantao.Atd_nomal2,
                Atd_status = request.UpdateAtendimentoPlantao.Atd_status,
                Atd_usucri = request.UpdateAtendimentoPlantao.Atd_usucri,
                Atd_usualt = request.UpdateAtendimentoPlantao.Atd_usualt,
                Atd_datcri = request.UpdateAtendimentoPlantao.Atd_datcri,
                Atd_datalt = request.UpdateAtendimentoPlantao.Atd_datalt
            };            

            await _unitOfWork.WriteDataFor<AtendimentoPlantao>().UpdateAsync(updateAtendimentoPlantao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateAtendimentoPlantao.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteAtendimentoPlantaoCommandsHandler : IRequestHandler<DeleteAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteAtendimentoPlantaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<AtendimentoPlantao>().GetByIdAsync(request.IdAtendimentoPlantaoToDelete);

        if (atendimentoPlantaoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<AtendimentoPlantao>().DeleteAsync(atendimentoPlantaoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(atendimentoPlantaoToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
