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

namespace Application.Features.Queries.QueriesHandler.FuncaoQueriesHandler;

public class GetFuncaoHandlerByStatus : IRequestHandler<GetFuncaoByStatus, ResponseWrapper<List<FuncaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetFuncaoHandlerByStatus(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<FuncaoResponse>>> Handle(GetFuncaoByStatus request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.StatusFuncao))
        {
            var FuncaoToFind = _unitOfWork.ReadDataFor<Funcao>()
            .Entities
            .Where(Funcao => Funcao.Fnc_ativo == request.StatusFuncao)
            .ToList();

            if (FuncaoToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<FuncaoResponse>>().
                    Success(FuncaoToFind.
                    Adapt<List<FuncaoResponse>>()));
            }
            return new ResponseWrapper<List<FuncaoResponse>>().Failed("Registro não encontrado");
        }
        return new ResponseWrapper<List<FuncaoResponse>>().Failed("Parâmetro obrigatório não preenchido");
    }
}