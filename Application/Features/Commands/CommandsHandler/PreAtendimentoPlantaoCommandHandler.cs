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

        return new ResponseWrapper<int>().Success(PreAtendimentoPlantao.Id, "Registro criado com sucesso.");
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
        var PreAtendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().GetByIdAsync(request.UpdatePreAtendimentoPlantao.Id);

        if (PreAtendimentoPlantaoToFind is not null)
        {
            var updatePreAtendimentoPlantao = new PreAtendimentoPlantao
            {
                Id = request.UpdatePreAtendimentoPlantao.Id,
                Ptd_titulo = request.UpdatePreAtendimentoPlantao.Ptd_titulo,
                Ptd_datptd = request.UpdatePreAtendimentoPlantao.Ptd_datptd,
                Ptd_usu_identi = request.UpdatePreAtendimentoPlantao.Ptd_usu_identi,
                Ptd_cli_identi = request.UpdatePreAtendimentoPlantao.Ptd_cli_identi,
                Ptd_tipptd = request.UpdatePreAtendimentoPlantao.Ptd_tipptd,
                Ptd_critic = request.UpdatePreAtendimentoPlantao.Ptd_critic,
                Ptd_resumo = request.UpdatePreAtendimentoPlantao.Ptd_resumo,
                Ptd_numcha = request.UpdatePreAtendimentoPlantao.Ptd_numcha,
                Ptd_jirarl = request.UpdatePreAtendimentoPlantao.Ptd_jirarl,
                Ptd_numjir = request.UpdatePreAtendimentoPlantao.Ptd_numjir,
                Ptd_diagn1 = request.UpdatePreAtendimentoPlantao.Ptd_diagn1,
                Ptd_status = request.UpdatePreAtendimentoPlantao.Ptd_status,
                Ptd_reton2 = request.UpdatePreAtendimentoPlantao.Ptd_reton2,
                Ptd_observ = request.UpdatePreAtendimentoPlantao.Ptd_observ,
                Ptd_nomal1 = request.UpdatePreAtendimentoPlantao.Ptd_nomal1,
                Ptd_numatd = request.UpdatePreAtendimentoPlantao.Ptd_numatd,
                Ptd_usubdd = request.UpdatePreAtendimentoPlantao.Ptd_usubdd,
                Ptd_datcri = request.UpdatePreAtendimentoPlantao.Ptd_datcri,
                Ptd_datalt = request.UpdatePreAtendimentoPlantao.Ptd_datalt,
                Ptd_usucri = request.UpdatePreAtendimentoPlantao.Ptd_usucri,
                Ptd_usualt = request.UpdatePreAtendimentoPlantao.Ptd_usualt,
                Ptd_linjir = request.UpdatePreAtendimentoPlantao.Ptd_linjir,
                Ptd_verjir = request.UpdatePreAtendimentoPlantao.Ptd_verjir
            };                            

            await _unitOfWork.WriteDataFor<PreAtendimentoPlantao>().UpdateAsync(updatePreAtendimentoPlantao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updatePreAtendimentoPlantao.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeletePreAtendimentoPlantaoCommandsHandler : IRequestHandler<DeletePreAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeletePreAtendimentoPlantaoCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeletePreAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var PreAtendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().GetByIdAsync(request.IdPreAtendimentoPlantaoToDelete);

        if (PreAtendimentoPlantaoToFind is not null)
        {
            await _unitOfWork.WriteDataFor<PreAtendimentoPlantao>().DeleteAsync(PreAtendimentoPlantaoToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(PreAtendimentoPlantaoToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}
