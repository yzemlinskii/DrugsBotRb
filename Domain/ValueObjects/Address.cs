using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;
using System.Xml.Linq;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Объект значения, представляющий адрес.
    /// </summary>
    public class Address : BaseValueObject
    {
        /// <summary>
        /// Конструктор для инициализации адреса.
        /// </summary>
        /// <param name="city">Город. Обязательное поле.</param>
        /// <param name="street">Улица. Обязательное поле.</param>
        /// <param name="house">Номер дома. Обязательное поле.</param>
        public Address(string city, string street, string house)
        {
            City = Guard.Against.NullOrWhiteSpace(city, nameof(city), ValidationMessage.NullOrWhitespaceMessage);
            Street = Guard.Against.NullOrWhiteSpace(street, nameof(street), ValidationMessage.NullOrWhitespaceMessage);
            House = Guard.Against.NullOrWhiteSpace(house, nameof(house), ValidationMessage.NullOrWhitespaceMessage);

            var validator = new AddressValidator();
            validator.Validate(this);
        }
        
        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string House { get; private set; }

        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, представляющая адрес.</returns>
        public override string ToString()
        {
            return $"{City}, {Street}, {House}";
        }
    }
}