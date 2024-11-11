using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetDadosListasAll : IRequest<ResponseWrapper<List<DadosListasResponse>>>
{

}

public class GetDadosListasById : IRequest<ResponseWrapper<DadosListasResponse>>
{
    public int Id { get; set; }
}


