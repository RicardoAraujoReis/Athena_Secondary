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

namespace Application.Features.Queries.QueriesHandler.UsuarioQueriesHandler;

public class GetUsuarioHandlerAll : IRequestHandler<GetUsuarioAll, ResponseWrapper<List<UsuarioResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetUsuarioHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<UsuarioResponse>>> Handle(GetUsuarioAll request, CancellationToken cancellationToken)
    {
        var usuarioToFind = await _unitOfWork.ReadDataFor<Usuario>().GetAllAsync();

        if (usuarioToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<UsuarioResponse>>().
                Success(usuarioToFind.
                Adapt<List<UsuarioResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<UsuarioResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}