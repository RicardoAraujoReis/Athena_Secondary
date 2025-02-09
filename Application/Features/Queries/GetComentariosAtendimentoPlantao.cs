using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetComentariosAtendimentoPlantaoAll : IRequest<ResponseWrapper<List<ComentariosAtendimentoPlantaoResponse>>>
{

}

public class GetComentarioAtendimentoPlantaoById : IRequest<ResponseWrapper<ComentariosAtendimentoPlantaoResponse>>
{
    public int Id { get; set; }
}
