using Common.Requests;
using FluentValidation;

namespace Athena.Web.Validators.PreAtendimentoPlantaoValidators;

public class ComentariosAtendimentoPlantaoValidator : AbstractValidator<CreateComentariosAtendimentoPlantao>
{
    public ComentariosAtendimentoPlantaoValidator()
    {
        RuleFor(preAtendimento => preAtendimento.Cap_coment)
            .Must(descri => !string.IsNullOrEmpty(descri)).WithMessage("Campo obrigatório")
            .MinimumLength(20).WithMessage("Tamanho mínimo 20 caracteres")
            .MaximumLength(255).WithMessage("Tamanho máximo 255 caracteres");        
    }

    public Func<object, string, Task<IEnumerable<string>>> Validate => async (requestModel, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateComentariosAtendimentoPlantao>
            .CreateWithOptions((CreateComentariosAtendimentoPlantao)requestModel, x => x.IncludeProperties(propertyName)));

        if (result.IsValid)
        {
            return Array.Empty<string>();
        }
        return result.Errors.Select(x => x.ErrorMessage);
    };
}
