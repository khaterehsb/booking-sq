﻿namespace SquareFish.Core
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }

    }
}
