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

public class GetUsuarioHandlerByStatus : IRequestHandler<GetUsuarioByStatus, ResponseWrapper<List<UsuarioResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetUsuarioHandlerByStatus(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<UsuarioResponse>>> Handle(GetUsuarioByStatus request, CancellationToken cancellationToken)
    {
        if(!string.IsNullOrEmpty(request.StatusUsuario))
        {
            var UsuarioToFind = _unitOfWork.ReadDataFor<Usuario>()
            .Entities
            .Where(Usuario => Usuario.Usu_ativo == request.StatusUsuario)
            .ToList();

            if (UsuarioToFind is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<UsuarioResponse>>().
                    Success(UsuarioToFind.
                    Adapt<List<UsuarioResponse>>()));
            }
            return new ResponseWrapper<List<UsuarioResponse>>().Failed("Registro não encontrado");
        }
        return new ResponseWrapper<List<UsuarioResponse>>().Failed("Parâmetro obrigatório não preenchido");
    }
}