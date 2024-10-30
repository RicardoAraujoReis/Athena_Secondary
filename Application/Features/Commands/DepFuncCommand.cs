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

public class CreateDepFuncCommand : IRequest<ResponseWrapper<int>>
{
    public CreateDepFunc CreateDepFunc { get; set; }        
}

public class UpdateDepFuncCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateDepFunc UpdateDepFunc { get; set; }
}

public class DeleteDepFuncCommand : IRequest<ResponseWrapper<int>>
{
    public int IdDepFuncToDelete { get; set; }
}
