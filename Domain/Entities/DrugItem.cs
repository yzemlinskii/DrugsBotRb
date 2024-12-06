﻿using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// </summary>
    public class DrugItem : BaseEntity
    {
        /// <sumary>
        /// Консруктор для инициализации связи между препаратом и аптекой
        /// <param name="drugId">ID препарата. Обязательное поле.</param>
        /// <param name="drugStoreId">ID аптеки. Обязательное поле.</param>
        /// <param name="cost">Цена препарата. Обязательное поле.</param>
        /// <param name="count">Количество препарата. Обязательное поле.</param>
        /// </sumary>
        public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count)
        {
            DrugId = Guard.Against.Null(drugId, nameof(drugId), ValidationMessage.NullOrWhitespaceMessage);
            DrugStoreId = Guard.Against.Null(drugStoreId, nameof(drugStoreId), ValidationMessage.NullOrWhitespaceMessage);
            Cost = Guard.Against.Null(cost, nameof(cost), ValidationMessage.NullOrWhitespaceMessage);
            Count = Guard.Against.Null(count, nameof(count), ValidationMessage.NullOrWhitespaceMessage);

            /// <summary>
            /// Валидация переданых параметров
            /// </summary>
            var validator = new DrugItemValidator();
            validator.Validate(this);
        }

        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }
        
        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid DrugStoreId { get; private set; }
        
        /// <summary>
        /// Стоимость препарата в данной аптеке.
        /// </summary>
        public decimal Cost { get; private set; }
        
        /// <summary>
        /// Количество препарата на складе.
        /// </summary>
        public int Count { get; private set; }
    }
}