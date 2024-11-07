using Athena.Models;
using common.Requests;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands;

public class CreateClienteCommand : IRequest<ResponseWrapper<int>>
{
    public CreateCliente CreateCliente { get; set; }        
}

public class UpdateClienteCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateCliente UpdateCliente { get; set; }
}

public class DeleteClienteCommand : IRequest<ResponseWrapper<int>>
{
    public int IdClienteToDelete { get; set; }
}
