using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetPreAtendimentoPlantaoAll : IRequest<ResponseWrapper<List<PreAtendimentoPlantaoResponse>>>
{

}

public class GetPreAtendimentoPlantaoById : IRequest<ResponseWrapper<PreAtendimentoPlantaoResponse>>
{
    public int Id { get; set; }
}


