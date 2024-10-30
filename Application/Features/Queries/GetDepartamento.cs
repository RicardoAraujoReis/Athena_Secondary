using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetDepartamentoAll : IRequest<ResponseWrapper<List<DepartamentoResponse>>>
{

}

public class GetDepartamentoById : IRequest<ResponseWrapper<DepartamentoResponse>>
{
    public int Dpt_identi { get; set; }
}


