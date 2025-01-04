using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.FuncaoValidators;

public class FuncaoValidator : AbstractValidator<CreateFuncao>
{
    public FuncaoValidator()
    {
        RuleFor(funcao => funcao.Fnc_descri)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(5).WithMessage("Tamanho mínimo 5 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");

        RuleFor(funcao => funcao.Fnc_ativo)
            .Must(ativo => !string.IsNullOrEmpty(ativo)).WithMessage("Campo obrigatório")
            .MaximumLength(1).WithMessage("Tamanho máximo 1 caractere");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateFuncao>
            .CreateWithOptions((CreateFuncao)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
