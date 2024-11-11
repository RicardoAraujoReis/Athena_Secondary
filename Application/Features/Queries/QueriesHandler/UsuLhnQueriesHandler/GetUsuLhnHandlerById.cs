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

namespace Application.Features.Queries.QueriesHandler.UsuLhnQueriesHandler;

public class GetUsuLhnHandlerById : IRequestHandler<GetUsuLhnById, ResponseWrapper<UsuLhnResponse>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetUsuLhnHandlerById(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<UsuLhnResponse>> Handle(GetUsuLhnById request, CancellationToken cancellationToken)
    {
        var usuLhnToFind = await _unitOfWork.ReadDataFor<UsuLhn>().GetByIdAsync(request.Id);

        if (usuLhnToFind is not null)
        {
            return await Task.
                FromResult(new ResponseWrapper<UsuLhnResponse>().
                Success(usuLhnToFind.
                Adapt<UsuLhnResponse>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<UsuLhnResponse>().
                Failed("Registro não encontrado"));
    }
}