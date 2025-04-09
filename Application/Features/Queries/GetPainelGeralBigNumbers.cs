using Common.Responses;
using Common.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries;


public class GetPainelGeralBigNumbersCurrent : IRequest<ResponseWrapper<List<PainelGeralBigNumbersResponse>>>
{

}

public class GetPainelGeralBigNumbersAll : IRequest<ResponseWrapper<List<PainelGeralBigNumbersResponse>>>
{

}