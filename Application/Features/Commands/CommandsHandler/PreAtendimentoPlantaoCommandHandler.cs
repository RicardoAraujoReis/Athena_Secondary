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

public class CreatePreAtendimentoPlantaoCommandsHandler : IRequestHandler<CreatePreAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreatePreAtendimentoPlantaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreatePreAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var PreAtendimentoPlantao = request.CreatePreAtendimentoPlantao.Adapt<PreAtendimentoPlantao>();
        await _unitOfWork.WriteDataFor<PreAtendimentoPlantao>().AddAsync(PreAtendimentoPlantao);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(PreAtendimentoPlantao.Ptd_identi, "Registro criado com sucesso.");
    }
}

public class UpdatePreAtendimentoPlantaoCommandsHandler : IRequestHandler<UpdatePreAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdatePreAtendimentoPlantaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdatePreAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var PreAtendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().GetByIdAsync(request.UpdatePreAtendimentoPlantao.Ptd_identi);

        if (PreAtendimentoPlantaoToFind is not null)
        {
            var updatePreAtendimentoPlantao = PreAtendimentoPlantaoToFind.UpdatePreAtendimentoPlantao(
                request.UpdatePreAtendimentoPlantao.Ptd_identi,
                request.UpdatePreAtendimentoPlantao.Ptd_datptd,
                request.UpdatePreAtendimentoPlantao.Ptd_usu_identi,
                request.UpdatePreAtendimentoPlantao.Ptd_cli_identi,
                request.UpdatePreAtendimentoPlantao.Ptd_tipptd,
                request.UpdatePreAtendimentoPlantao.Ptd_critic,
                request.UpdatePreAtendimentoPlantao.Ptd_resumo,
                request.UpdatePreAtendimentoPlantao.Ptd_numcha,
                request.UpdatePreAtendimentoPlantao.Ptd_jirarl,
                request.UpdatePreAtendimentoPlantao.Ptd_numjir,
                request.UpdatePreAtendimentoPlantao.Ptd_diagn1,
                request.UpdatePreAtendimentoPlantao.Ptd_status,
                request.UpdatePreAtendimentoPlantao.Ptd_reton2,
                request.UpdatePreAtendimentoPlantao.Ptd_observ,
                request.UpdatePreAtendimentoPlantao.Ptd_nomal1,
                request.UpdatePreAtendimentoPlantao.Ptd_numatd,
                request.UpdatePreAtendimentoPlantao.Ptd_usubdd,
                request.UpdatePreAtendimentoPlantao.Ptd_datcri,
                request.UpdatePreAtendimentoPlantao.Ptd_datalt,
                request.UpdatePreAtendimentoPlantao.Ptd_usucri,
                request.UpdatePreAtendimentoPlantao.Ptd_usualt
            );

            await _unitOfWork.WriteDataFor<PreAtendimentoPlantao>().UpdateAsync(updatePreAtendimentoPlantao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updatePreAtendimentoPlantao.Ptd_identi, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeletePreAtendimentoPlantaoCommandsHandler : IRequestHandler<DeletePreAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public async Task<ResponseWrapper<int>> Handle(DeletePreAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var PreAtendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().GetByIdAsync(request.IdPreAtendimentoPlantaoToDelete);

        if (PreAtendimentoPlantaoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<PreAtendimentoPlantao>().DeleteAsync(PreAtendimentoPlantaoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(PreAtendimentoPlantaoToFind.Ptd_identi, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
