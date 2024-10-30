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

public class CreatePreAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public CreatePreAtendimentoPlantao CreatePreAtendimentoPlantao { get; set; }        
}

public class UpdatePreAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public UpdatePreAtendimentoPlantao UpdatePreAtendimentoPlantao { get; set; }
}

public class DeletePreAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public int IdPreAtendimentoPlantaoToDelete { get; set; }
}
