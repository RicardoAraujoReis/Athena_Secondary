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

public class CreateUsuarioCommand : IRequest<ResponseWrapper<int>>
{
    public CreateUsuario CreateUsuario { get; set; }        
}

public class UpdateUsuarioCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateUsuario UpdateUsuario { get; set; }
}

public class DeleteUsuarioCommand : IRequest<ResponseWrapper<int>>
{
    public int IdUsuarioToDelete { get; set; }
}
