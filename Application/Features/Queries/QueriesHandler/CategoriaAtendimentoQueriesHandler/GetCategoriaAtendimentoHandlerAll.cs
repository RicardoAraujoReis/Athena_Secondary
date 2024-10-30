using Athena.Models;
using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.QueriesHandler.CategoriaAtendimentoQueriesHandler;

public class GetCategoriaAtendimentoHandlerAll : IRequestHandler<GetCategoriaAtendimentoAll, ResponseWrapper<List<CategoriaAtendimentoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetCategoriaAtendimentoHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<CategoriaAtendimentoResponse>>> Handle(GetCategoriaAtendimentoAll request, CancellationToken cancellationToken)
    {
        var categoriaAtendimentoToFind = await _unitOfWork.ReadDataFor<CategoriaAtendimento>().GetAllAsync();

        if (categoriaAtendimentoToFind.Count > 0)
        {
            return new ResponseWrapper<List<CategoriaAtendimentoResponse>>().Success(categoriaAtendimentoToFind.Adapt<List<CategoriaAtendimentoResponse>>());
        }
        return new ResponseWrapper<List<CategoriaAtendimentoResponse>>().Failed("Não foram encontrados registros para a consulta realizada.");
    }        
}
