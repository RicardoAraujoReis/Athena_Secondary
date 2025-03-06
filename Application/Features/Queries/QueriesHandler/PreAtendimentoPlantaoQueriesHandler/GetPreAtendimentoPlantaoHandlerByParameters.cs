using Athena.Models;
using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using System.Linq;

namespace Application.Features.Queries.QueriesHandler.PreAtendimentoPlantaoQueriesHandler;

public class GetPreAtendimentoPlantaoHandlerByParameters : IRequestHandler<GetPreAtendimentoPlantaoByParameters, ResponseWrapper<List<PreAtendimentoPlantaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetPreAtendimentoPlantaoHandlerByParameters(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<PreAtendimentoPlantaoResponse>>> Handle(GetPreAtendimentoPlantaoByParameters request, CancellationToken cancellationToken)
    {
        if (request is not null)
        {
            var query = _unitOfWork.ReadDataFor<PreAtendimentoPlantao>().Entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Filtros.id))
            {                
                query = query.Where(p => p.Id == Convert.ToInt32(request.Filtros.id));
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.titulo))
            {
                query = query.Where(p => p.Ptd_titulo.ToUpper().Contains(request.Filtros.titulo.ToUpper()));
            }

            if (request.Filtros.linhaNegocioSelected > 0)
            {
                var clientes = _unitOfWork.ReadDataFor<Cliente>().Entities.Where(c => c.Cli_lhn_identi == request.Filtros.linhaNegocioSelected).Select(c => c.Id);

                query = query.Where(p => clientes.Contains(p.Ptd_cli_identi));
            }

            if (request.Filtros.clienteSelected > 0)
            {
                query = query.Where(p => p.Ptd_cli_identi == request.Filtros.clienteSelected);
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.statusSelected))
            {
                query = query.Where(p => p.Ptd_status == request.Filtros.statusSelected);
            }            

            if (request.Filtros.dataInicioPreAtendimento.HasValue)
            {
                query = query.Where(p => p.Ptd_datcri >= request.Filtros.dataInicioPreAtendimento.Value);
            }

            if (request.Filtros.dataFimPreAtendimento.HasValue)
            {
                query = query.Where(p => p.Ptd_datcri <= request.Filtros.dataFimPreAtendimento.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.resumo))
            {
                query = query.Where(p => p.Ptd_resumo.ToUpper().Contains(request.Filtros.resumo.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.tipoPreAtendimentoSelected))
            {
                query = query.Where(p => p.Ptd_tipptd.Equals(request.Filtros.tipoPreAtendimentoSelected));
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.criticidadeSelected))
            {
                if (request.Filtros.criticidadeSelected.Equals("TRIVIAL"))
                {
                    query = query.Where(p => p.Ptd_critic == "T");                    
                }
                else if (request.Filtros.criticidadeSelected.Equals("BAIXA"))
                {
                    query = query.Where(p => p.Ptd_critic == "B");
                }
                else if (request.Filtros.criticidadeSelected.Equals("MEDIA"))
                {
                    query = query.Where(p => p.Ptd_critic == "M");
                }
                else if (request.Filtros.criticidadeSelected.Equals("ALTA"))
                {
                    query = query.Where(p => p.Ptd_critic == "A");
                }
                else
                {
                    query = query.Where(p => p.Ptd_critic == "C");
                }
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.jira))
            {
                query = query.Where(p => p.Ptd_jirarl.Contains(request.Filtros.jira));
            }

            var result = query.ToList();

            if (result is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<PreAtendimentoPlantaoResponse>>().
                    Success(data: result.
                    Adapt<List<PreAtendimentoPlantaoResponse>>()));
            }
        }
        
        return await Task.
            FromResult(new ResponseWrapper<List<PreAtendimentoPlantaoResponse>>().
            Failed("Registro não encontrado"));
    }
}