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

public class CreateFuncaoCommand : IRequest<ResponseWrapper<int>>
{
    public CreateFuncao CreateFuncao { get; set; }        
}

public class UpdateFuncaoCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateFuncao UpdateFuncao { get; set; }
}

public class DeleteFuncaoCommand : IRequest<ResponseWrapper<int>>
{
    public int IdFuncaoToDelete { get; set; }
}
