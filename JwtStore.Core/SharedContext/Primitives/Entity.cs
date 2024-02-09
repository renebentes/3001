namespace JwtStore.Core.SharedContext.Primitives;

public abstract class Entity : IEquatable<Guid>
{
    protected Entity()
        => Id = Guid.NewGuid();

    public Guid Id { get; }

    public bool Equals(Guid id)
        => Id == id;

    public override int GetHashCode()
        => Id.GetHashCode();
}
