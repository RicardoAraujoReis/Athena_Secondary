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

public class CreateDadosListasCommand : IRequest<ResponseWrapper<int>>
{
    public CreateDadosListas CreateDadosListas { get; set; }        
}

public class UpdateDadosListasCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateDadosListas UpdateDadosListas { get; set; }
}

public class DeleteDadosListasCommand : IRequest<ResponseWrapper<int>>
{
    public int IdDadosListasToDelete { get; set; }
}
