using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// </summary>
        /// <param name="name">Название страны. Обязательное поле.</param>
        /// <param name="code">Код страны. Обязательное поле.</param>
        public Country(string name, string code)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhitespaceMessage);
            Code = Guard.Against.NullOrWhiteSpace(code, nameof(code), ValidationMessage.NullOrWhitespaceMessage);

            /// <summary>
            /// Валидация переданых параметров
            /// </summary>
            var validator = new CountryValidator();
            validator.Validate(this);
        }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }
    }
}