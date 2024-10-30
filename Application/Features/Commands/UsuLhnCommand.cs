using Athena.Models;
using Common.Requests;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands;

public class CreateUsuLhnCommand : IRequest<ResponseWrapper<int>>
{
    public CreateUsuLhn CreateUsuLhn { get; set; }        
}

public class UpdateUsuLhnCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateUsuLhn UpdateUsuLhn { get; set; }
}

public class DeleteUsuLhnCommand : IRequest<ResponseWrapper<int>>
{
    public int IdUsuLhnToDelete { get; set; }
}
