using FluentValidation;
using Real_Estate_Management_System_düzenleme.DTO;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public class PropertyValidator : AbstractValidator<PropertyDto>
    {
        public PropertyValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("İlan başlığı boş olamaz.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır.");
        }
    }

}