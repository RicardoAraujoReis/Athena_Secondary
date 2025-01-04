using Athena.Web.Pages.Cadastros.CategoriaAtendimento;
using Common.Requests;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Athena.Web.Validators.CategoriaAtendimentoValidators;

public class CategoriaAtendimentoValidator : AbstractValidator<CreateCategoriaAtendimento>
{
    public CategoriaAtendimentoValidator()
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
        var result = await ValidateAsync(ValidationContext<CreateCategoriaAtendimento>
            .CreateWithOptions((CreateCategoriaAtendimento)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
