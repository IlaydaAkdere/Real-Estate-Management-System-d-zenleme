using FluentValidation;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public class PropertyValidator : AbstractValidator<PropertyDto>
    {
        public PropertyValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Başlık zorunludur.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama zorunludur.");
        }
    }

}
