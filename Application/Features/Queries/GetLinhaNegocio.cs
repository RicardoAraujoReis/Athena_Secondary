using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;

public class GetLinhaNegocioAll : IRequest<ResponseWrapper<List<LinhaNegocioResponse>>>
{

}

public class GetLinhaNegocioById : IRequest<ResponseWrapper<LinhaNegocioResponse>>
{
    public int Id { get; set; }
}

public class GetLinhaNegocioByStatus : IRequest<ResponseWrapper<LinhaNegocioResponse>>
{
    public String LinhaNegocioByStatus { get; set; }
}

public class GetLinhaNegocioBySearchParameters : IRequest<ResponseWrapper<LinhaNegocioResponse>>
{
    public int Id { get; set; }
    public String LinhaNegocioByStatus { get; set; }
}
