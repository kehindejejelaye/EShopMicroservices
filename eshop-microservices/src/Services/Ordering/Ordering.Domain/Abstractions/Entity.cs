﻿namespace Ordering.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "Test";
    public DateTime? LastModified { get; set; }
    public string LastModifiedBy { get; set; } = "Test";
}
