using Athena.Models;
using Common.Responses;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.QueriesHandler.AtendimentoPlantaoQueriesHandler;

public class GetAtendimentoPlantaoHandlerByParameters : IRequestHandler<GetAtendimentoPlantaoByParameters, ResponseWrapper<List<AtendimentoPlantaoResponse>>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public GetAtendimentoPlantaoHandlerByParameters(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<List<AtendimentoPlantaoResponse>>> Handle(GetAtendimentoPlantaoByParameters request, CancellationToken cancellationToken)
    {
        if (request is not null)
        {
            var query = _unitOfWork.ReadDataFor<AtendimentoPlantao>().Entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Filtros.id))
            {
                query = query.Where(p => p.Id == Convert.ToInt32(request.Filtros.id));
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.titulo))
            {
                query = query.Where(p => p.Atd_titulo.ToUpper().Contains(request.Filtros.titulo.ToUpper()));
            }

            if (request.Filtros.linhaNegocioSelected > 0)
            {
                var clientes = _unitOfWork.ReadDataFor<Cliente>().Entities.Where(c => c.Cli_lhn_identi == request.Filtros.linhaNegocioSelected).Select(c => c.Id);

                query = query.Where(p => clientes.Contains(p.Atd_cli_identi));
            }

            if (request.Filtros.clienteSelected > 0)
            {
                query = query.Where(p => p.Atd_cli_identi == request.Filtros.clienteSelected);
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.statusSelected))
            {
                query = query.Where(p => p.Atd_status == request.Filtros.statusSelected);
            }

            if (request.Filtros.dataInicioAtendimento.HasValue)
            {
                query = query.Where(p => p.Atd_datcri >= request.Filtros.dataInicioAtendimento.Value);
            }

            if (request.Filtros.dataFimAtendimento.HasValue)
            {
                query = query.Where(p => p.Atd_datcri <= request.Filtros.dataFimAtendimento.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.resumo))
            {
                query = query.Where(p => p.Atd_resumo.ToUpper().Contains(request.Filtros.resumo.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.tipoAtendimentoSelected))
            {
                query = query.Where(p => p.Atd_tipatd.Equals(request.Filtros.tipoAtendimentoSelected));
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.criticidadeSelected))
            {
                if (request.Filtros.criticidadeSelected.Equals("TRIVIAL"))
                {
                    query = query.Where(p => p.Atd_critic == "T");
                }
                else if (request.Filtros.criticidadeSelected.Equals("BAIXA"))
                {
                    query = query.Where(p => p.Atd_critic == "B");
                }
                else if (request.Filtros.criticidadeSelected.Equals("MEDIA"))
                {
                    query = query.Where(p => p.Atd_critic == "M");
                }
                else if (request.Filtros.criticidadeSelected.Equals("ALTA"))
                {
                    query = query.Where(p => p.Atd_critic == "A");
                }
                else
                {
                    query = query.Where(p => p.Atd_critic == "C");
                }
            }

            if (!string.IsNullOrWhiteSpace(request.Filtros.jira))
            {
                query = query.Where(p => p.Atd_jirarl.Contains(request.Filtros.jira));
            }

            var result = query.ToList();

            if (result is not null)
            {
                return await Task.
                    FromResult(new ResponseWrapper<List<AtendimentoPlantaoResponse>>().
                    Success(data: result.
                    Adapt<List<AtendimentoPlantaoResponse>>()));
            }
        }

        return await Task.
            FromResult(new ResponseWrapper<List<AtendimentoPlantaoResponse>>().
            Failed("Registro não encontrado"));
    }
}
