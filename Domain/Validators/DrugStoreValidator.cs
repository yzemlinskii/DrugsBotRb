using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

/// <sumary>
/// Валидатор полей для создания аптеки.
/// </sumary>
namespace Domain.Validators
{
    public class DrugStoreValidator : AbstractValidator<DrugStore>
    {
        public DrugStoreValidator()
        {
            /// <sumary>
            /// Правило для поля Аптечная сеть. Длина от 2 до 100 символов.
            /// </sumary>
            RuleFor(ds => ds.DrugNetwork)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage);

            /// <sumary>
            /// Правило для поля Номер. Должен быть больше нуля, либо равен нулю.
            /// </sumary>
            RuleFor(ds => ds.Number)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.InvalidValueMessage);
        }
    }
}
