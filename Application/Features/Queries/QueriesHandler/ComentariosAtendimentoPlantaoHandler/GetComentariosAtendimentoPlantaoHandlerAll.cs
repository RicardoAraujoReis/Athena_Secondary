using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using Models;

namespace Application.Features.Queries.QueriesHandler.AtendimentoPlantaoQueriesHandler;

public class GetComentariosAtendimentoPlantaoHandlerAll : IRequestHandler<GetComentariosAtendimentoPlantaoAll, ResponseWrapper<List<ComentariosAtendimentoPlantaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetComentariosAtendimentoPlantaoHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<ComentariosAtendimentoPlantaoResponse>>> Handle(GetComentariosAtendimentoPlantaoAll request, CancellationToken cancellationToken)
    {
        var atendimentoPlantaoToFind = await _unitOfWork.ReadDataFor<ComentariosAtendimentoPlantao>().GetAllAsync();

        if (atendimentoPlantaoToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<ComentariosAtendimentoPlantaoResponse>>().
                Success(atendimentoPlantaoToFind.
                Adapt<List<ComentariosAtendimentoPlantaoResponse>>()));
        }
        return await Task.
            FromResult(new ResponseWrapper<List<ComentariosAtendimentoPlantaoResponse>>().
            Failed("Não foram encontrados registros para a consulta realizada."));
    }
}