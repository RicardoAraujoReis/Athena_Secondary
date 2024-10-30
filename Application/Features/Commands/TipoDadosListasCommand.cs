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

public class CreateTipoDadosListasCommand : IRequest<ResponseWrapper<int>>
{
    public CreateTipoDadosListas CreateTipoDadosListas { get; set; }        
}

public class UpdateTipoDadosListasCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateTipoDadosListas UpdateTipoDadosListas { get; set; }
}

public class DeleteTipoDadosListasCommand : IRequest<ResponseWrapper<int>>
{
    public int IdTipoDadosListasToDelete { get; set; }
}
