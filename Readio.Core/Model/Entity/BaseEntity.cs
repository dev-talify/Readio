namespace Readio.Core.Model.Entity;

public abstract class BaseEntity<TId>
{
    public TId Id { get; private set; } = default!;
    
}