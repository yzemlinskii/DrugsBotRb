using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.ValueObjects;
using Domain.Primitives;

namespace Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .Length(3, 100).WithMessage(ValidationMessage.LengthMessage);
            RuleFor(a => a.City)
                .Length(2, 50).WithMessage(ValidationMessage.LengthMessage);
            RuleFor(a => a.House)
                .Length(2, 100).WithMessage(ValidationMessage.LengthMessage);
        }
    }
}
