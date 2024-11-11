using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetClienteAll : IRequest<ResponseWrapper<List<ClienteResponse>>>
{

}

public class GetClienteById : IRequest<ResponseWrapper<ClienteResponse>>
{
    public int Id { get; set; }
}


