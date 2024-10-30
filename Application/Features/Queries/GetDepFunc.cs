using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetDepFuncAll : IRequest<ResponseWrapper<List<DepFuncResponse>>>
{

}

public class GetDepFuncById : IRequest<ResponseWrapper<DepFuncResponse>>
{
    public int Dfc_identi { get; set; }
}


