using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetFuncaoAll : IRequest<ResponseWrapper<List<FuncaoResponse>>>
{

}

public class GetFuncaoById : IRequest<ResponseWrapper<FuncaoResponse>>
{
    public int Id { get; set; }
}

public class GetFuncaoByStatus : IRequest<ResponseWrapper<List<FuncaoResponse>>>
{
    public string StatusFuncao { get; set; }
}
