using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetCategoriaAtendimentoAll : IRequest<ResponseWrapper<List<CategoriaAtendimentoResponse>>>
{

}

public class GetCategoriaAtendimentoById : IRequest<ResponseWrapper<CategoriaAtendimentoResponse>>
{
    public int Cat_identi { get; set; }
}


