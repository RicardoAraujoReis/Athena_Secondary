using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.LinhaNegocioValidators;

public class LinhaNegocioValidator : AbstractValidator<CreateLinhaNegocio>
{
    public LinhaNegocioValidator()
    {
        RuleFor(linhaNegocio => linhaNegocio.Lhn_descri)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(3).WithMessage("Tamanho mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");

        RuleFor(linhaNegocio => linhaNegocio.Lhn_ativo)
            .Must(ativo => !string.IsNullOrEmpty(ativo)).WithMessage("Campo obrigatório")
            .MaximumLength(1).WithMessage("Tamanho máximo 1 caractere");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateLinhaNegocio>
            .CreateWithOptions((CreateLinhaNegocio)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
