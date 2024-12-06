using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public static class ValidationMessage
    {
        public const string NullOrWhitespaceMessage = "Поле не может быть пустым или состоять из пробелов";
        public const string LengthMessage = "Поле {PropertyName} должно содержать от {MinLength} до {MaxLength}";
        public const string InvalidValueMessage = "Недопустимое значение";
    }
}
