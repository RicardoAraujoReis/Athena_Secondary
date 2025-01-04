using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.CategoriaAtendimentoValidators;

public class UpdateCategoriaAtendimentoValidator : AbstractValidator<UpdateCategoriaAtendimento>
{
    public UpdateCategoriaAtendimentoValidator()
    {
        RuleFor(categoriaAtendimento => categoriaAtendimento.Cat_valor)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MaximumLength(10).WithMessage("Tamanho máximo 10 caracteres")
            .MinimumLength(5).WithMessage("Tamanho mínimo 5 caracteres");

        RuleFor(categoriaAtendimento => categoriaAtendimento.Cat_nivel)
        .NotNull().WithMessage("Campo obrigatório");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateCategoriaAtendimento>
            .CreateWithOptions((UpdateCategoriaAtendimento)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
};