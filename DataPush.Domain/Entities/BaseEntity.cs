namespace DataPush.Domain.Entities;

public abstract class BaseEntity
{
    public static Guid Id => Guid.NewGuid();
}