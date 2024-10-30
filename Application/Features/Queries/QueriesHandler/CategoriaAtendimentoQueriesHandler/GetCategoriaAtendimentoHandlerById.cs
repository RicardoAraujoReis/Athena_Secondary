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

public class GetCategoriaAtendimentoHandlerById : IRequestHandler<GetCategoriaAtendimentoById, ResponseWrapper<CategoriaAtendimentoResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetCategoriaAtendimentoHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<CategoriaAtendimentoResponse>> Handle(GetCategoriaAtendimentoById request, CancellationToken cancellationToken)
    {
        var categoriaAtendimentoToFind = await _unitOfWork.ReadDataFor<CategoriaAtendimento>().GetByIdAsync(request.Cat_identi);

        if (categoriaAtendimentoToFind is not null)
        {
            return new ResponseWrapper<CategoriaAtendimentoResponse>().Success(categoriaAtendimentoToFind.Adapt<CategoriaAtendimentoResponse>());
        }
        return new ResponseWrapper<CategoriaAtendimentoResponse>().Failed("Registro não encontrado");
    }
}
