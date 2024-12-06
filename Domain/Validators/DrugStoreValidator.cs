using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;

using Domain.Primitives;

namespace Domain.Validators
{
    public class DrugStoreValidator : AbstractValidator<DrugStore>
    {
        public DrugStoreValidator()
        {
            RuleFor(ds => ds.DrugNetwork)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage);
            RuleFor(ds => ds.Number)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.InvalidValueMessage);
        }
    }
}
