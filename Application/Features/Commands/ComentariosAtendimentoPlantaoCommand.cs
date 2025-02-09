using Athena.Models;
using Common.Requests;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands;

public class CreateComentariosAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public CreateComentariosAtendimentoPlantao CreateComentariosAtendimentoPlantao { get; set; }        
}

public class UpdateComentariosAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateComentariosAtendimentoPlantao UpdateComentariosAtendimentoPlantao { get; set; }
}

public class DeleteComentariosAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public int IdComentarioToDelete { get; set; }
}
