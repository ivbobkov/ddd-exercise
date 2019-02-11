﻿using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public class Purchase : IEntity<Guid>
    {
        public Purchase(Guid id, Money value, DateTime spentAt)
        {
            Id = id;
            Value = value;
            SpentAt = spentAt;
        }

        public Guid Id { get; }
        public Money Value { get; }
        public DateTime SpentAt { get; }

        public static Purchase Create(Money value, DateTime spentAt)
        {
            return new Purchase(Guid.NewGuid(), value, spentAt);
        }
    }
}
