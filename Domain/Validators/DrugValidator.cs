using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;
using Domain.Primitives;
using System.Globalization;

/// <sumary>
/// Валидатор полей для создания аптеки.
/// </sumary>
namespace Domain.Validators
{
    public class DrugValidator : AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            /// <sumary>
            /// Правило для поля Имя. От 2 до 100 символов, состоит из русского/английского алфавита , пробелов, строчных/заглавных букв. 
            /// </sumary>
            RuleFor(d => d.Name)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
                .Matches("^[a-zA-Zа-яА-ЯёЁ ]+$").WithMessage("Имя не может содержать специальные символы.");

            /// <sumary>
            /// Правило для поля Производитель. От 2 до 100 символов, состоит из русского/английского алфавита, пробелов, строчных/заглавных букв или дефисов. 
            /// </sumary>
            RuleFor(d => d.Manufacturer)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
                .Matches("^[a-zA-Zа-яА-ЯёЁ -]+$").WithMessage("Имя может содержать только буквы, пробелы и дефисы.");

            /// <sumary>
            /// Правило для поля Айди кода страны. Должен существовать в справочнике стран. 
            /// </sumary>
            RuleFor(d => d.CountryCodeId)
                .Must(IsValidCountryCode).WithMessage("Неверный айди страны.");
        }

        /// <summary>
        /// Проверка валидности Айди кода страны.
        /// </summary>
        /// <param name="CountryCodeId"> Айди кода страны.</param>
        /// <returns></returns>
        private bool IsValidCountryCode(string CountryCodeId)
        {
            try
            {
                /// <sumary>
                /// Если можно получить RegionInfo - функция возвращает True, соответственно, проходит проверку на валидность.
                /// </sumary>
                var _ = new RegionInfo(CountryCodeId);
                return true;
            }
            catch
            {
                /// <sumary>
                /// Если нельзя получить RegionInfo - функция возвращает False, соответственно, не проходит проверку на валидность.
                /// </sumary>
                return false;
            }
        }
    }
}
