using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.PreAtendimentoPlantaoValidators;

public class PreAtendimentoPlantaoValidator : AbstractValidator<CreatePreAtendimentoPlantao>
{
    public PreAtendimentoPlantaoValidator()
    {
        RuleFor(preAtendimento => preAtendimento.Ptd_resumo)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(20).WithMessage("Tamanho mínimo 20 caracteres")
            .MaximumLength(255).WithMessage("Tamanho máximo 255 caracteres");

        RuleFor(preAtendimento => preAtendimento.Ptd_numcha)
            .Must(numcha => !string.IsNullOrEmpty(numcha)).WithMessage("Campo obrigatório")
            .MinimumLength(5).WithMessage("Tamanho mínimo 5 caracteres")
            .MaximumLength(20).WithMessage("Tamanho máximo 20 caracteres");

        RuleFor(preAtendimento => preAtendimento.Ptd_diagn1)
            .Must(numcha => !string.IsNullOrEmpty(numcha)).WithMessage("Campo obrigatório")
            .MinimumLength(20).WithMessage("Tamanho mínimo 20 caracteres")
            .MaximumLength(255).WithMessage("Tamanho máximo 255 caracteres");

        RuleFor(preAtendimento => preAtendimento.Ptd_observ)                        
            .MaximumLength(255).WithMessage("Tamanho máximo 255 caracteres");

        RuleFor(preAtendimento => preAtendimento.Ptd_linjir)
            .MaximumLength(255).WithMessage("Tamanho máximo 255 caracteres");

        RuleFor(preAtendimento => preAtendimento.Ptd_verjir)
            .MaximumLength(65).WithMessage("Tamanho máximo 65 caracteres");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreatePreAtendimentoPlantao>
            .CreateWithOptions((CreatePreAtendimentoPlantao)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
