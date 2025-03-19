using Common.Requests.Searchs;
using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetAtendimentoPlantaoAll : IRequest<ResponseWrapper<List<AtendimentoPlantaoResponse>>>
{

}

public class GetAtendimentoPlantaoById : IRequest<ResponseWrapper<AtendimentoPlantaoResponse>>
{
    public int Id { get; set; }
}

public class GetAtendimentoPlantaoByParameters : IRequest<ResponseWrapper<List<AtendimentoPlantaoResponse>>>
{
    public SearchAtendimentoPlantaoByParameters Filtros { get; }

    public GetAtendimentoPlantaoByParameters(SearchAtendimentoPlantaoByParameters filtros)
    {
        Filtros = filtros;
    }
}