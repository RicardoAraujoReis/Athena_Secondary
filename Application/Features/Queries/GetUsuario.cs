using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetUsuarioAll : IRequest<ResponseWrapper<List<UsuarioResponse>>>
{

}

public class GetUsuarioById : IRequest<ResponseWrapper<UsuarioResponse>>
{
    public int Id { get; set; }
}


