using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.TipoDadosListasValidators;

public class UpdateTipoDadosListasValidator : AbstractValidator<UpdateTipoDadosListas>
{
    public UpdateTipoDadosListasValidator()
    {
        RuleFor(tipoDadosListas => tipoDadosListas.Tid_descri)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(3).WithMessage("Tamanho mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");       
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateTipoDadosListas>
            .CreateWithOptions((UpdateTipoDadosListas)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
