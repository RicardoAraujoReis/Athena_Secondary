using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.AtendimentoPlantaoValidators;

public class UpdateAtendimentoPlantaoValidator : AbstractValidator<UpdateAtendimentoPlantao>
{
    public UpdateAtendimentoPlantaoValidator()
    {
        RuleFor(atendimento => atendimento.Atd_linjir)
            .MaximumLength(255).WithMessage("Tamanho máximo 255 caracteres");

        RuleFor(atendimento => atendimento.Atd_verjir)
                .MaximumLength(65).WithMessage("Tamanho máximo 65 caracteres");
    }
}
