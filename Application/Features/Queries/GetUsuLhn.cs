using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetUsuLhnAll : IRequest<ResponseWrapper<List<UsuLhnResponse>>>
{

}

public class GetUsuLhnById : IRequest<ResponseWrapper<UsuLhnResponse>>
{
    public int Id { get; set; }
}


