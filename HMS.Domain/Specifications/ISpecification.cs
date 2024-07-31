﻿namespace HMS.Domain.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        string ErrorMessage { get; }
    }
}
