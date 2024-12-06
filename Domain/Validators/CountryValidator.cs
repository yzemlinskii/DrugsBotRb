using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

/// <sumary>
/// Валидатор полей для создания страны.
/// </sumary>
namespace Domain.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            /// <sumary>
            /// Правило для поля Имя. Состоит из русского/английского алфавита, строчных/заглавных букв и пробелов. 
            /// </sumary>
            RuleFor(c => c.Name)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
                .Matches("^[a-zA-Zа-яА-ЯёЁ ]+$").WithMessage("Имя может содержать только буквы и пробелы.");

            /// <sumary>
            /// Правило для поля Код. Состоит из 2 заглавных букв латинского алкфавита. 
            /// </sumary>
            RuleFor(d => d.Code)
                .Matches(@"^[A-Z]{2}$").WithMessage("Код страны должен состоять из двух заглавных латинских букв.");
        }
    }
}
