using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Validators
{
    public class DrugItemValidator : AbstractValidator<DrugItem>
    {
        public DrugItemValidator()
        {
            RuleFor(di => di.Cost)
                .GreaterThan(0).WithMessage(ValidationMessage.InvalidValueMessage)
                .LessThan(9999999).WithMessage(ValidationMessage.InvalidValueMessage)
                .Must(cost => cost == Math.Round(cost, 2)).WithMessage(ValidationMessage.InvalidValueMessage);

            RuleFor(di => di.Count)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.InvalidValueMessage)
                .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.InvalidValueMessage);
        }
    }
}
