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

public class CreateCategoriaAtendimentoCommand : IRequest<ResponseWrapper<int>>
{
    public CreateCategoriaAtendimento CreateCategoriaAtendimento { get; set; }        
}

public class UpdateCategoriaAtendimentoCommand : IRequest<ResponseWrapper<int>>
{
    public UpdateCategoriaAtendimento UpdateCategoriaAtendimento { get; set; }
}

public class DeleteCategoriaAtendimentoCommand : IRequest<ResponseWrapper<int>>
{
    public int IdCategoriaAtendimentoToDelete { get; set; }
}
