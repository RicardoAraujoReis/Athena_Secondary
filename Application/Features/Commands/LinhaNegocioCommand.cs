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

public class CreateLinhaNegocioCommand : IRequest<ResponseWrapper<int>>
{
    public CreateLinhaNegocio CreateLinhaNegocio { get; set; }        
}

public class UpdateLinhaNegocioCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateLinhaNegocio UpdateLinhaNegocio { get; set; }
}

public class DeleteLinhaNegocioCommand : IRequest<ResponseWrapper<int>>
{
    public int IdLinhaNegocioToDelete { get; set; }
}
