using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetTipoDadosListasAll : IRequest<ResponseWrapper<List<TipoDadosListasResponse>>>
{

}

public class GetTipoDadosListasById : IRequest<ResponseWrapper<TipoDadosListasResponse>>
{
    public int Tid_identi { get; set; }
}


