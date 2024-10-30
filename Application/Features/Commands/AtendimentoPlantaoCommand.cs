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

public class CreateAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public CreateAtendimentoPlantao CreateAtendimentoPlantao { get; set; }        
}

public class UpdateAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateAtendimentoPlantao UpdateAtendimentoPlantao { get; set; }
}

public class DeleteAtendimentoPlantaoCommand : IRequest<ResponseWrapper<int>>
{
    public int IdAtendimentoPlantaoToDelete { get; set; }
}
