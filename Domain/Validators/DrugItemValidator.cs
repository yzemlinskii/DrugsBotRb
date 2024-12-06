using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

/// <sumary>
/// Валидатор полей для создания связи между препаратом и аптекой.
/// </sumary>
namespace Domain.Validators
{
    public class DrugItemValidator : AbstractValidator<DrugItem>
    {
        public DrugItemValidator()
        {
            /// <sumary>
            /// Правила для поля Цена. Больше нуля, меньше 9999999, должна содержать не более двух знаков после запятой.
            /// </sumary>
            RuleFor(di => di.Cost)
                .GreaterThan(0).WithMessage(ValidationMessage.InvalidValueMessage)
                .LessThan(9999999).WithMessage(ValidationMessage.InvalidValueMessage)
                .Must(cost => cost == Math.Round(cost, 2)).WithMessage(ValidationMessage.InvalidValueMessage);

            /// <sumary>
            /// Правила для поля Количество. Больше нуля, меньше 10000.
            /// </sumary>
            RuleFor(di => di.Count)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.InvalidValueMessage)
                .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.InvalidValueMessage);
        }
    }
}
