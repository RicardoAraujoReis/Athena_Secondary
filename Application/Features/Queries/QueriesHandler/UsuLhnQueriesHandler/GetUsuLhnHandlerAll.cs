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

public class GetUsuLhnHandlerAll : IRequestHandler<GetUsuLhnAll, ResponseWrapper<List<UsuLhnResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetUsuLhnHandlerAll(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<UsuLhnResponse>>> Handle(GetUsuLhnAll request, CancellationToken cancellationToken)
    {
        var usuLhnToFind = await _unitOfWork.ReadDataFor<UsuLhn>().GetAllAsync();

        if (usuLhnToFind.Count > 0)
        {
            return await Task.
                FromResult(new ResponseWrapper<List<UsuLhnResponse>>().
                Success(usuLhnToFind.
                Adapt<List<UsuLhnResponse>>()));
        }
        return await Task.
                FromResult(new ResponseWrapper<List<UsuLhnResponse>>().
                Failed("Não foram encontrados registros para a consulta realizada."));
    }
}