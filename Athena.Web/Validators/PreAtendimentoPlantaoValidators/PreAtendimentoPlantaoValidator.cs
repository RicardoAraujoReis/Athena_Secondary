using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.PreAtendimentoPlantaoValidators;

public class PreAtendimentoPlantaoValidator : AbstractValidator<CreatePreAtendimentoPlantao>
{
    public PreAtendimentoPlantaoValidator()
    {
        RuleFor(preAtendimento => preAtendimento.Ptd_resumo)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(10).WithMessage("Tamanho mínimo 10 caracteres")
            .MaximumLength(200).WithMessage("Tamanho máximo 200 caracteres");
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
