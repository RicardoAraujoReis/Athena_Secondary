using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using Models;

namespace Application.Features.Queries.QueriesHandler.AtendimentoPlantaoQueriesHandler;

public class GetComentarioAtendimentoPlantaoHandlerById : IRequestHandler<GetComentarioAtendimentoPlantaoById, ResponseWrapper<ComentariosAtendimentoPlantaoResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetComentarioAtendimentoPlantaoHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<ComentariosAtendimentoPlantaoResponse>> Handle(GetComentarioAtendimentoPlantaoById request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<ComentariosAtendimentoPlantao>().GetByIdAsync(request.Id);

        if (atendimentoPlantaoToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<ComentariosAtendimentoPlantaoResponse>().
                Success(atendimentoPlantaoToFind.Adapt<ComentariosAtendimentoPlantaoResponse>()));
        }
        return await Task.
            FromResult(new ResponseWrapper<ComentariosAtendimentoPlantaoResponse>().
            Failed("Registro não encontrado"));
    }
}