using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
                .Matches("^[a-zA-Zа-яА-ЯёЁ ]+$").WithMessage("Имя может содержать только буквы и пробелы.");

            RuleFor(d => d.Code)
                .Matches(@"^[A-Z]{2}$").WithMessage("Код страны должен состоять из двух заглавных латинских букв.");
        }
    }
}
