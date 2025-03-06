using Common.Requests;
using Common.Requests.Searchs;
using FluentValidation;

namespace Athena.Web.Validators.PreAtendimentoPlantaoValidators;

public class ConsultaPreAtendimentoPlantaoValidator : AbstractValidator<SearchPreAtendimentoPlantaoByParameters>
{
    public ConsultaPreAtendimentoPlantaoValidator()
    {
        RuleFor(preAtendimento => preAtendimento.titulo)            
            .MinimumLength(20).WithMessage("Tamanho mínimo 20 caracteres")
            .MaximumLength(65).WithMessage("Tamanho máximo 65 caracteres");
    }
}