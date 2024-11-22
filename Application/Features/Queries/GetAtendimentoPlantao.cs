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

public class GetAtendimentoPlantaoByStatus : IRequest<ResponseWrapper<List<AtendimentoPlantaoResponse>>>
{
    public string AtendimentoByStatus { get; set; }
}