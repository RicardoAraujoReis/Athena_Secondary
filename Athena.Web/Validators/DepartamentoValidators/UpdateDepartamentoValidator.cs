using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.DepartamentoValidators;

public class UpdateDepartamentoValidator : AbstractValidator<UpdateDepartamento>
{
    public UpdateDepartamentoValidator()
    {
        RuleFor(departamento => departamento.Dpt_descri)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(5).WithMessage("Tamanho mínimo 5 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");

        RuleFor(departamento => departamento.Dpt_ativo)
            .Must(ativo => !string.IsNullOrEmpty(ativo)).WithMessage("Campo obrigatório")
            .MaximumLength(1).WithMessage("Tamanho máximo 1 caractere");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateDepartamento>
            .CreateWithOptions((UpdateDepartamento)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
