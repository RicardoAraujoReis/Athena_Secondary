using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.DadosListasValidators;

public class DadosListasValidator : AbstractValidator<CreateDadosListas>
{
    public DadosListasValidator()
    {
        RuleFor(tipoDadosListas => tipoDadosListas.Dal_valor)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(3).WithMessage("Tamanho mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateDadosListas>
            .CreateWithOptions((CreateDadosListas)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
