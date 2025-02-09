using Common.Requests;
using Common.Wrapper;
using Mapster;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CommandsHandler;

public class CreateComentariosAtendimentoPlantaoCommandHandler : IRequestHandler<CreateComentariosAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateComentariosAtendimentoPlantaoCommandHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ResponseWrapper<int>> Handle(CreateComentariosAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var comentarioAtendimento = request.CreateComentariosAtendimentoPlantao.Adapt<ComentariosAtendimentoPlantao>();
        await _unitOfWork.WriteDataFor<ComentariosAtendimentoPlantao>().AddAsync(comentarioAtendimento);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(comentarioAtendimento.Id, "Registro criado com sucesso.");
    }
}

public class UpdateComentariosAtendimentoPlantaoCommandHandler : IRequestHandler<UpdateComentariosAtendimentoPlantaoCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateComentariosAtendimentoPlantaoCommandHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseWrapper<int>> Handle(UpdateComentariosAtendimentoPlantaoCommand request, CancellationToken cancellationToken)
    {
        var ComentarioToFind = await _unitOfWork.ReadDataFor<ComentariosAtendimentoPlantao>().GetByIdAsync(request.UpdateComentariosAtendimentoPlantao.Id);

        if (ComentarioToFind is not null)
        {
            var updateCategoriaAtendimento = new ComentariosAtendimentoPlantao
            {
                Id = request.UpdateComentariosAtendimentoPlantao.Id,
                Cap_coment = request.UpdateComentariosAtendimentoPlantao.Cap_coment,
                Cap_usubdd = request.UpdateComentariosAtendimentoPlantao.Cap_usubdd,
                Cap_usucri = request.UpdateComentariosAtendimentoPlantao.Cap_usucri,
                Cap_usualt = request.UpdateComentariosAtendimentoPlantao.Cap_usualt,
                Cap_datcri = request.UpdateComentariosAtendimentoPlantao.Cap_datcri,
                Cap_datalt = request.UpdateComentariosAtendimentoPlantao.Cap_datalt                
            };

            await _unitOfWork.WriteDataFor<ComentariosAtendimentoPlantao>().UpdateAsync(ComentarioToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateCategoriaAtendimento.Id, "Atualização realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}
