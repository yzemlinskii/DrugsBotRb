using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.ValueObjects;
using Domain.Primitives;

/// <sumary>
/// Валидатор полей для создания адреса.
/// </sumary>
namespace Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            /// <sumary>
            /// Правило для поля Улица. Больше 3 и меньше 100 символов.
            /// </sumary>
            RuleFor(a => a.Street)
                .Length(3, 100).WithMessage(ValidationMessage.LengthMessage);

            /// <sumary>
            /// Правило для поля Город. Больше 2 и меньше 50 символов.
            /// </sumary>
            RuleFor(a => a.City)
                .Length(2, 50).WithMessage(ValidationMessage.LengthMessage);

            /// <sumary>
            /// Правило для поля Дом. Больше 2 и меньше 100 символов.
            /// </sumary>
            RuleFor(a => a.House)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage);
        }
    }
}
