using Ardalis.GuardClauses;
using Domain.Primitives;
using System.Xml.Linq;
using Domain.ValueObjects;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации класса с аптекой.
        /// </summary>
        /// <param name="drugNetwork">Название аптечной сети. Обязательное поле.</param>
        /// <param name="number">Номер аптеки. Должно быть больше нуля.</param>
        /// <param name="address">Адрес аптеки. Обязательное поле.</param>
        public DrugStore(string drugNetwork, int number, Address address)
        {
            DrugNetwork = Guard.Against.NullOrWhiteSpace(drugNetwork, nameof(drugNetwork), ValidationMessage.NullOrWhitespaceMessage);
            Number = Guard.Against.Negative(number, nameof(number), ValidationMessage.InvalidValueMessage);
            Address = Guard.Against.Null(address, nameof(address), ValidationMessage.NullOrWhitespaceMessage);

            /// <summary>
            /// Валидация переданых параметров
            /// </summary>
            var validator = new DrugStoreValidator();
            validator.Validate(this);
        }

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
    }
}