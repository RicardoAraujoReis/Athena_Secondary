using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.UsuarioValidators;

public class UpdateUsuarioValidator : AbstractValidator<UpdateUsuario>
{
    public UpdateUsuarioValidator()
    {
        RuleFor(usuario => usuario.Usu_descri)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(3).WithMessage("Tamanho mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");

        RuleFor(usuario => usuario.Usu_login)
            .Must(login => !string.IsNullOrEmpty(login)).WithMessage("Campo obrigatório")
            .MinimumLength(5).WithMessage("Tamanho mínimo 5 caracteres")
            .MaximumLength(35).WithMessage("Tamanho máximo 35 caracteres");

        RuleFor(usuario => usuario.Usu_email)
            .EmailAddress().WithMessage("Campo obrigatório")
            .MinimumLength(20).WithMessage("Tamanho mínimo 20 caracteres")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres");

        RuleFor(usuario => usuario.Usu_senha)
            .Must(senha => !string.IsNullOrEmpty(senha)).WithMessage("Campo obrigatório")
            .MaximumLength(100).WithMessage("Tamanho máximo 100 caracteres")
            .MinimumLength(8).WithMessage("Tamanho mínimo 8 caracteres");

        RuleFor(usuario => usuario.Usu_ativo)
            .Must(ativo => !string.IsNullOrEmpty(ativo)).WithMessage("Campo obrigatório")
            .MaximumLength(1).WithMessage("Tamanho máximo 1 caractere");

        RuleFor(usuario => usuario.Usu_status)
            .Must(status => !string.IsNullOrEmpty(status)).WithMessage("Campo obrigatório")
            .MaximumLength(1).WithMessage("Tamanho máximo 1 caractere");

        RuleFor(usuario => usuario.Usu_master)
            .Must(master => !string.IsNullOrEmpty(master)).WithMessage("Campo obrigatório")
            .MaximumLength(1).WithMessage("Tamanho máximo 1 caractere");
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateUsuario>
            .CreateWithOptions((UpdateUsuario)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
