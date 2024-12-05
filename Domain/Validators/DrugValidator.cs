using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;
using Domain.Primitives;
using System.Globalization;

namespace Domain.Validators
{
    public class DrugValidator : AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            RuleFor(d => d.Name)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
                .Matches("^[a-zA-Zа-яА-ЯёЁ ]+$").WithMessage("Имя не может содержать специальные символы.");

            RuleFor(d => d.Manufacturer)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
                .Matches("^[a-zA-Zа-яА-ЯёЁ -]+$").WithMessage("Имя может содержать только буквы, пробелы и дефисы.");
            RuleFor(d => d.CountryCodeId)
                .Must(IsValidCountryCode).WithMessage("Неверный айди страны.");
        }
        private bool IsValidCountryCode(string countryCode)
        {
            try
            {
                var _ = new RegionInfo(countryCode);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
