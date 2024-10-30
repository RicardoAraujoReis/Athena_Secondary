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

public class CreateDepartamentoCommand : IRequest<ResponseWrapper<int>>
{
    public CreateDepartamento CreateDepartamento { get; set; }        
}

public class UpdateDepartamentoCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateDepartamento UpdateDepartamento { get; set; }
}

public class DeleteDepartamentoCommand : IRequest<ResponseWrapper<int>>
{
    public int IdDepartamentoToDelete { get; set; }
}
