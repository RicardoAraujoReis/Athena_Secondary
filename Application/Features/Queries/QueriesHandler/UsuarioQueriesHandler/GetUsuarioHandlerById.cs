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

public class GetUsuarioHandlerById : IRequestHandler<GetUsuarioById, ResponseWrapper<UsuarioResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetUsuarioHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<UsuarioResponse>> Handle(GetUsuarioById request, CancellationToken cancellationToken)
    {
        var usuarioToFind = await _unitOfWork.ReadDataFor<Usuario>().GetByIdAsync(request.Usu_identi);

        if (usuarioToFind is not null)
        {
            return new ResponseWrapper<UsuarioResponse>().Success(usuarioToFind.Adapt<UsuarioResponse>());
        }
        return new ResponseWrapper<UsuarioResponse>().Failed("Registro não encontrado");
    }
}
