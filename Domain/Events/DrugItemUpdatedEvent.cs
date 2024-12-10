﻿using Domain.Interfaces;

namespace Domain.Events;

internal class DrugItemUpdatedEvent : IDomainEvent
{
    private readonly decimal? _cost;
    private readonly double? _count;

    internal DrugItemUpdatedEvent(decimal? cost, double? count)
    {
        _cost = cost;
        _count = count;
    }
}